using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class FriendCommandBehavior : MonoBehaviour
{
    public Transform StairsTransform;
    public Transform SafeTransform;
    public Transform EntranceTransform;
    public Transform LaserTransform;
    public NavMeshAgent NavMeshAgent;
    public GameObject UI;
    public GameObject GameOverUI;
    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveToBox()
    {
        // Find the closest BROWN_BOX object
        GameObject[] brownBoxes = GameObject.FindGameObjectsWithTag("BROWN_BOX");
        Transform closestBrownBox = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject brownBox in brownBoxes)
        {
            float distance = Vector3.Distance(transform.position, brownBox.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestBrownBox = brownBox.transform;
            }
        }

        // Move to the closest BROWN_BOX
        if (closestBrownBox != null)
        {
            NavMeshAgent.SetDestination(closestBrownBox.position);
            Debug.Log("Moving to the closest box");
        }
        else
        {
            Debug.LogWarning("No box found");
        }
    }

    public void MoveToShelf()
    {
        // Find the closest SHELF object
        GameObject[] shelves = GameObject.FindGameObjectsWithTag("SHELF");
        Transform closestShelf = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject shelf in shelves)
        {
            float distance = Vector3.Distance(transform.position, shelf.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestShelf = shelf.transform;
            }
        }

        // Move to the closest SHELF
        if (closestShelf != null)
        {
            NavMeshAgent.SetDestination(closestShelf.position);
            Debug.Log("Moving to the closest shelf");
        }
        else
        {
            Debug.LogWarning("No shelf found");
        }
    }


    public void MoveToEntrance()
    {
        NavMeshAgent.SetDestination(EntranceTransform.position);
        Debug.Log("MoveToEntrance");
    }
    public void MoveToLaser()
    {
        NavMeshAgent.SetDestination(LaserTransform.position);
        Debug.Log("MoveToLaser");
    }

    public void MoveToStairs()
    {
        NavMeshAgent.SetDestination(StairsTransform.position);
        Debug.Log("MoveToStairs");
    }

    public void MoveToCrates()
    {
        GameObject[] blackCrates = GameObject.FindGameObjectsWithTag("BLACK_CHEST");
        Transform closestBlackCrate = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject blackCrate in blackCrates)
        {
            float distance = Vector3.Distance(transform.position, blackCrate.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestBlackCrate = blackCrate.transform;
            }
        }

        if (closestBlackCrate != null)
        {
            NavMeshAgent.SetDestination(closestBlackCrate.position);
            Debug.Log("Moving to the closest crate");
        }
        else
        {
            Debug.LogWarning("No crate found");
        }
    }

    public void MoveToCarpets()
    {
        GameObject[] carpets = GameObject.FindGameObjectsWithTag("CARPET");
        Transform closestCarpet = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject carpet in carpets)
        {
            float distance = Vector3.Distance(transform.position, carpet.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestCarpet = carpet.transform;
            }
        }

        if (closestCarpet != null)
        {
            NavMeshAgent.SetDestination(closestCarpet.position);
            Debug.Log("Moving to the closest carpet");
        }
        else
        {
            Debug.LogWarning("No carpet found");
        }
    }

    public void MoveToSafe()
    {
        NavMeshAgent.SetDestination(SafeTransform.position);
        Debug.Log("MoveToSafe");
    }

    public void MoveToPlants()
    {
        GameObject[] plants = GameObject.FindGameObjectsWithTag("PLANT");
        Transform closestplant = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject plant in plants)
        {
            float distance = Vector3.Distance(transform.position, plant.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestplant = plant.transform;
            }
        }

        // Move to the closest BROWN_BOX
        if (closestplant != null)
        {
            NavMeshAgent.SetDestination(closestplant.position);
            Debug.Log("Moving to the closest plant");
        }
        else
        {
            Debug.LogWarning("No plant found");
        }
    }

    public void MoveToColumn()
    {
        // Find the closest BROWN_BOX object
        GameObject[] columns = GameObject.FindGameObjectsWithTag("COLUMNS");
        Transform closestColumn = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject column in columns)
        {
            float distance = Vector3.Distance(transform.position, column.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestColumn = column.transform;
            }
        }

        // Move to the closest BROWN_BOX
        if (closestColumn != null)
        {
            NavMeshAgent.SetDestination(closestColumn.position);
            Debug.Log("Moving to the closest column");
        }
        else
        {
            Debug.LogWarning("No column found");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("SCHERMATA DI SCONFITTA");

        }
    }
}
