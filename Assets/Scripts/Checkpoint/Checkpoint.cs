using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public checkpointData checkpointPosition;

    void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            checkpointPosition.position = gameObject.transform.position;
        }     
    }
}
