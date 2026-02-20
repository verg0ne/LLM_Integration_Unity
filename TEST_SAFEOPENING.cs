using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEST_SAFEOPENING : MonoBehaviour
{
    public float PotentiometerValue;
    public GameObject Door;
    public GameObject WinUI;
    public GameObject GameUI;
    public GameObject Safe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OpenSesame(string open)
    {
        String[] allDatasAsStrings = open.Split('/');

        PotentiometerValue = float.Parse(allDatasAsStrings[17], System.Globalization.CultureInfo.InvariantCulture);

        Door.transform.eulerAngles = new Vector3(0f, (90f * PotentiometerValue)- 70f, 0f);

        if (PotentiometerValue >= 2.8f && Safe.activeSelf)
        {
            SceneManager.LoadScene("SCHERMATA DI VITTORIA");
        } 

    }
}
