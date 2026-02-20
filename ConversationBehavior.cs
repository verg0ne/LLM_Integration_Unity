using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LLMUnity;
using TMPro;

public class ConversationBehavior : MonoBehaviour
{
    public LLMCharacter MyCharacter;
    public TMP_InputField MyInputField;
    public TMP_Text TextResponse;

    public void TriggerLLM()
    {
        _ = MyCharacter.Chat(MyInputField.text, AiResponse);
        MyInputField.text = string.Empty;
    }

    void AiResponse(string inResponse)
    {
        TextResponse.text = inResponse;
    }
}