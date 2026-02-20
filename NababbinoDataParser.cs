using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NababbinoDataParser : MonoBehaviour
{
    public int LedValueToSet = 255;

    public float AccX, AccY, AccZ, GyroX, GyroY, GyroZ, Roll, Pitch, Yaw, Temperature, MicLevel, Potentiometer;
    public int CapA, CapB;
    public bool LeftButton, RightButton, UpButton, DownButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ArduinoManager.Singleton.SendToArduino("PWM_LED:" + LedValueToSet.ToString());
        }
    }

    public void ParseDataFromNababbinoExample(string InputString)
    {
        string[] allDatasAsStrings = InputString.Split('/');

        AccX = float.Parse(allDatasAsStrings[0] , System.Globalization.CultureInfo.InvariantCulture);
        AccY = float.Parse(allDatasAsStrings[1], System.Globalization.CultureInfo.InvariantCulture);
        AccZ = float.Parse(allDatasAsStrings[2], System.Globalization.CultureInfo.InvariantCulture);

        GyroX = float.Parse(allDatasAsStrings[3], System.Globalization.CultureInfo.InvariantCulture);
        GyroY = float.Parse(allDatasAsStrings[4], System.Globalization.CultureInfo.InvariantCulture);
        GyroZ = float.Parse(allDatasAsStrings[5], System.Globalization.CultureInfo.InvariantCulture);

        Roll = float.Parse(allDatasAsStrings[6], System.Globalization.CultureInfo.InvariantCulture);
        Pitch = float.Parse(allDatasAsStrings[7], System.Globalization.CultureInfo.InvariantCulture);
        Yaw = float.Parse(allDatasAsStrings[8], System.Globalization.CultureInfo.InvariantCulture);

        Temperature = float.Parse(allDatasAsStrings[9], System.Globalization.CultureInfo.InvariantCulture);
        MicLevel = float.Parse(allDatasAsStrings[16], System.Globalization.CultureInfo.InvariantCulture);
        Potentiometer = float.Parse(allDatasAsStrings[17], System.Globalization.CultureInfo.InvariantCulture);

        CapA = int.Parse(allDatasAsStrings[10], System.Globalization.CultureInfo.InvariantCulture);
        CapB = int.Parse(allDatasAsStrings[11], System.Globalization.CultureInfo.InvariantCulture);

        LeftButton = int.Parse(allDatasAsStrings[12], System.Globalization.CultureInfo.InvariantCulture) == 1;
        RightButton = int.Parse(allDatasAsStrings[13], System.Globalization.CultureInfo.InvariantCulture) == 1;
        UpButton = int.Parse(allDatasAsStrings[14], System.Globalization.CultureInfo.InvariantCulture) == 1;
        DownButton = int.Parse(allDatasAsStrings[15], System.Globalization.CultureInfo.InvariantCulture) == 1;
        

    }

}
