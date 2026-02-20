using UnityEngine;

public class LaserDeactivationBehavior : MonoBehaviour
{
    public GameObject objectToDeactivate1;
    public GameObject objectToDeactivate2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToDeactivate1.SetActive(false);
            objectToDeactivate2.SetActive(false);
        }
    }
}