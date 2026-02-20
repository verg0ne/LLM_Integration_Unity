using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LLMUnity;
using TMPro;
using UnityEngine.Events;

public class TestCallFunction : MonoBehaviour
{
    public LLMCharacter MyCharacter;
    public TMP_InputField MyInputField;
    public TMP_Text TextResponse;
    public AiMultipleChoiceEvent[] MultipleChoiceEvents;
    public Transform playerTransform;
    string aiResponse;

    private void Start()
    {
        MyInputField.onEndEdit.AddListener(TriggerLLM);
        MyCharacter.grammarString = MultipleChoiceGrammar();
        print(ConstructPrompt("piedi"));
    }

    public void TriggerLLM(string inputString)
    {
        _ = MyCharacter.Chat(ConstructPrompt(inputString), AiResponse, ResponseCompleted);
        MyInputField.text = string.Empty;
    }

    void AiResponse(string inResponse)
    {
        print(inResponse);
        TextResponse.text = inResponse;
        aiResponse = inResponse;
    }

    GameObject GetNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float minDistance = Mathf.Infinity;
        Debug.Log("Got Enemies");

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(playerTransform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }
        Debug.Log("Returning Enemies");
        return nearestEnemy;
        
    }

    void ResponseCompleted()
    {
        print("risposta completa, risultato:" + aiResponse);
        InvokeRandomEvent();
    }


    void InvokeRandomEvent()
    {
        Debug.Log("Invoking Event");
        GameObject nearestEnemy = GetNearestEnemy();
        if (nearestEnemy != null)
        {
            float distance = Vector3.Distance(playerTransform.position, nearestEnemy.transform.position);
            float randomChance = Random.Range(0f, 1f);
            float maxDistance = 5f; // Adjust this value to change the maximum distance for the random event to occur

            if (distance <= maxDistance && randomChance <= (distance / maxDistance) * 0.5f)
            {
                // Invoke a random event
                int randomIndex = Random.Range(0, MultipleChoiceEvents.Length);
                MultipleChoiceEvents[randomIndex].AiTriggerEvent.Invoke();
                Debug.Log("Random event");
            }
            else
            {
                // Invoke the correct event
                GetEventFromTopic(aiResponse).Invoke();
                Debug.Log("Got it");
            }
        }
        else
        {
            // Invoke the correct event if no enemy is found
            GetEventFromTopic(aiResponse).Invoke();
        }
    }

    UnityEvent GetEventFromTopic(string topic)
    {
        for (int i = 0; i < MultipleChoiceEvents.Length; i++)
        {
            if (topic == MultipleChoiceEvents[i].TopicString)
            {
                return MultipleChoiceEvents[i].AiTriggerEvent;
                break;
            }
        }
        return null;
    }

    string MultipleChoiceGrammar()
    {
        return "root ::= (\"" + string.Join("\" | \"", GetFunctionNames()) + "\")";
    }

    string[] GetFunctionNames()
    {
        string[] multipleChoiceNames = new string[MultipleChoiceEvents.Length];
        for (int i = 0; i < MultipleChoiceEvents.Length; i++)
        {
            multipleChoiceNames[i] = MultipleChoiceEvents[i].TopicString;
        }

        return multipleChoiceNames;
    }

    string ConstructPrompt(string message)
    {
        string prompt = "Which of the following choices matches best the input?\n\n";
        prompt += "Input:" + message + "\n\n";
        prompt += "Choices:\n";

        for (int i = 0; i < MultipleChoiceEvents.Length; i++)
        {
            prompt += "- ";
            prompt += MultipleChoiceEvents[i].TopicString;
            prompt += "\n";
        }

        foreach (string functionName in GetFunctionNames()) prompt += $"- {functionName}\n";
        prompt += "\nAnswer directly with the choice";
        return prompt;
    }

    [System.Serializable]
    public class AiMultipleChoiceEvent
    {
        public string TopicString;
        public UnityEvent AiTriggerEvent;
    }
}