using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using System.Threading;
using UnityEngine.Events;

// REMEMBER TO SET THE API COMPATIBILITY LEVEL IN PLAYER SETTINGS TO .Net Framework OTHERWISE THIS SCRIPT WILL NOT WORK
public class ArduinoManager : MonoBehaviour
{
    public static ArduinoManager Singleton;

    [Tooltip("Useful if you don't know the port and in builds.")] // this could fail on some pc like alienwares that has a preinstalled arduino like board to manage leds.
    public bool GuessPortName = true;
    public string SerialPortName = "COM10";
    public int SerialPortBaudRate = 9600;
    [Space(20)]
    public StringEvent NewSerialValueEvent;


    SerialPort arduino;
    Thread arduinoThread;
    string lastSerialValue;
    bool isArduinoThreadRunning = true;


    private void OnEnable()
    {
        Singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GuessPortName)
        {
            string newSerialPort = GetFirstAvailablePort();
            if (!String.IsNullOrEmpty(newSerialPort))
            {
                SerialPortName = newSerialPort;
            }
        }

        arduino = new SerialPort(SerialPortName, SerialPortBaudRate);
        arduino.RtsEnable = true;
        arduino.DtrEnable = true;

        arduino.Open();

        arduinoThread = new Thread(ArduinoReadThread);
        arduinoThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(lastSerialValue))
        {
            Debug.Log(lastSerialValue);
            NewSerialValueEvent.Invoke(lastSerialValue);
            lastSerialValue = null;
        }
    }

    public void SendToArduino(string MessageToSend)
    {
        arduino.WriteLine(MessageToSend);
    }

    void ArduinoReadThread()
    {
        isArduinoThreadRunning = true;
        while (isArduinoThreadRunning)
        {
            if (arduino.IsOpen)
            {
                lastSerialValue = arduino.ReadLine();
            }
        }
        arduino.Close();
    }

    
    // The magic function to estimate roughly the port where arduino could be connected...
    string GetFirstAvailablePort()
    {
        string[] ports = SerialPort.GetPortNames();
        if (ports.Length > 0)
        {
            // Prova ad aprire la prima porta disponibile
            string firstPort = ports[0];
            try
            {
                using (SerialPort serialPort = new SerialPort(firstPort, SerialPortBaudRate))
                {
                    serialPort.Open();
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                        return firstPort; // Porta aperta con successo, restituisci il nome della porta
                    }
                }
            }
            catch (System.Exception)
            {
                return null;
            }
        }
        return null; // Nessuna porta trovata o non è stato possibile aprire la porta
    }

    private void OnApplicationQuit()
    {
        isArduinoThreadRunning = false;
        arduinoThread.Abort();
        arduino.Close();
    }

    // Here I create a UnityEvent that supports strings, such as the Ui TextField object, so I can send an event with the content of the serial.
    [Serializable]
    public class StringEvent : UnityEvent<string> { }
}
