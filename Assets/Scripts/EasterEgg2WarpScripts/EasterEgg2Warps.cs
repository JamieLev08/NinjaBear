using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg2Warps : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    private void OnTriggerEnter2D (Collider2D other)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }
}
