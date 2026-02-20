using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject[] cameras = GameObject.FindGameObjectsWithTag("Camera");
            foreach (GameObject camera in cameras)
            {
                camera.SetActive(false);
            }
            Camera.SetActive(true); 
        }
    }
}
