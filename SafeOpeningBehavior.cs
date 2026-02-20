using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeOpeningBehavior : MonoBehaviour
{
    [SerializeField]
    const float Combination1 = 0.3f;
    const float Combination2 = 1.2f;
    const float Combination3 = 1.8f;
    public float PotentiometerValue;
    public Transform Knob;

    public AudioClip Combination1Sound;
    public AudioClip Combination2Sound;
    public AudioClip Combination3Sound;

    private AudioSource audioSource;
    private bool combination1Played = false;
    private bool combination2Played = false;
    private bool combination3Played = false;
    private bool correctOrder = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void UpdateRotation(string Pot)
    {
        String[] allDatasAsStrings = Pot.Split('/');

        PotentiometerValue = -(float.Parse(allDatasAsStrings[17], System.Globalization.CultureInfo.InvariantCulture) - 2f);
        Knob.transform.rotation = Quaternion.Euler(0f, -90f, PotentiometerValue * 180f);

        if (Mathf.Abs(PotentiometerValue - Combination1) <= 0.2f && !combination1Played)
        {
            audioSource.PlayOneShot(Combination1Sound);
            combination1Played = true;
        }
        else if (Mathf.Abs(PotentiometerValue - Combination2) <= 0.2f && combination1Played && !combination2Played)
        {
            audioSource.PlayOneShot(Combination2Sound);
            combination2Played = true;
            Debug.Log("Second Combination");
        }
        else if (Mathf.Abs(PotentiometerValue - Combination3) <= 0.2f && combination2Played && !combination3Played)
        {
            audioSource.PlayOneShot(Combination3Sound);
            combination3Played = true;
            Debug.Log("Third Combination");

            if (correctOrder)
            {
                transform.Rotate(Vector3.up, 90f);
            }
            else
            {
                ResetCombinations();
            }
        }
    }
    private void ResetCombinations()
    {
        combination1Played = false;
        combination2Played = false;
        combination3Played = false;
        correctOrder = false;
    }

    private void CheckCorrectOrder()
    {
        if (combination1Played && combination2Played && combination3Played)
        {
            correctOrder = true;
        }
    }
}