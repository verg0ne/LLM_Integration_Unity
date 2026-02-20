using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneManager : MonoBehaviour
{
    public GameObject targetObject;
    public float MicLevel;

    // Start is called before the first frame update
    public void ChangeWidth(string Mic)
    {
        // Assuming NababbinoDataParser is a static class and MicLevel is a public static float
        String[] allDatasAsStrings = Mic.Split('/');

        MicLevel = float.Parse(allDatasAsStrings[16]);
        targetObject.transform.localScale = new Vector3(MicLevel * 20f, targetObject.transform.localScale.y, MicLevel * 20f);
    }
}