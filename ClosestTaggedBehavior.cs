using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestTaggedBehavior : MonoBehaviour
{
    public string[] targetTags = { "BLACK_CHEST", "BROWN_BOX", "COLUMNS", "PLANT", "SHELF", "CARPET"  };
    public GameObject prefabToPlace;
    public float maxDistance = Mathf.Infinity;

    private Dictionary<string, GameObject> closestObjects;
    private Dictionary<string, GameObject> placedPrefabs;

    void Start()
    {
        closestObjects = new Dictionary<string, GameObject>();
        placedPrefabs = new Dictionary<string, GameObject>();
    }

    void Update()
    {
        foreach (string tag in targetTags)
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
            GameObject closestObject = GetClosestObject(taggedObjects);

            if (closestObject != null)
            {
                if (!closestObjects.ContainsKey(tag) || closestObjects[tag] != closestObject)
                {
                    if (closestObjects.ContainsKey(tag))
                    {
                        GameObject oldPrefab = placedPrefabs[tag];
                        Destroy(oldPrefab);
                        placedPrefabs.Remove(tag);
                    }

                    closestObjects[tag] = closestObject;
                    GameObject newPrefab = Instantiate(prefabToPlace, closestObject.transform.position, Quaternion.identity);
                    placedPrefabs[tag] = newPrefab;
                }
            }
        }
    }

    private GameObject GetClosestObject(GameObject[] objects)
    {
        GameObject closestObject = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject obj in objects)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if (distance < minDistance && distance <= maxDistance)
            {
                minDistance = distance;
                closestObject = obj;
            }
        }

        return closestObject;
    }
}