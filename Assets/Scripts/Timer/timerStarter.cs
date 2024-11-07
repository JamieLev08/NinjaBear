using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerStarter : MonoBehaviour
{
    public timerData timer_Data;
    public bool invert;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(invert == true)
            {
                timer_Data.time = 0;
                timer_Data.start = false;
            }
            else
            {
                timer_Data.start = true;
            }
        }
    }
}
