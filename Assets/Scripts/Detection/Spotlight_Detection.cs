using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight_Detection : MonoBehaviour
{
    public DetectionAmount Detect;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Detect.insta_kill = true;
        }
    }
}
