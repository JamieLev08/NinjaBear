using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_destory : MonoBehaviour
{
    public bool collected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collected = true;
        }
    }

    private void Update()
    {
        if (collected == true)
        {
            Debug.Log("test");
            gameObject.SetActive(false);
        }
    }
}
