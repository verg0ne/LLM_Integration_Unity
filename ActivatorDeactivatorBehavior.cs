using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorDeactivatorBehavior : MonoBehaviour
{
    public GameObject targetObjectToActivate;
    public GameObject targetObjectToActivate2;
    public GameObject targetObjectToActivate3;
    public GameObject targetObjectToDeactivate;
    public GameObject targetObjectToDeactivate2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetObjectToActivate != null)
            {
                targetObjectToActivate.SetActive(true);
                targetObjectToActivate2.SetActive(true);
                targetObjectToActivate3.SetActive(true);

            }

            if (targetObjectToDeactivate != null)
            {
                targetObjectToDeactivate.SetActive(false);
                targetObjectToDeactivate2.SetActive(false);
            }
        }
    }
}