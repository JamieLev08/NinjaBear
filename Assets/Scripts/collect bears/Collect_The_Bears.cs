using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_The_Bears : MonoBehaviour
{
    public Bears_SO Bear;
    public GameObject BearObject;
    public GameObject Prompt;
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (BearObject != null)
            {
                if (BearObject.CompareTag("Teary"))
                {
                    Bear.Teary = true;
                }
                if (BearObject.CompareTag("Pawl"))
                {
                    Bear.Pawl = true;
                }
                if (BearObject.CompareTag("Nafurn"))
                {
                    Bear.Nafurn = true;
                }
                BearObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teary"))
        {
            BearObject = collision.gameObject;
            Prompt.SetActive(true);
        }
        if (collision.CompareTag("Pawl"))
        {
            BearObject = collision.gameObject;
            Prompt.SetActive(true);
        }
        if (collision.CompareTag("Nafurn"))
        {
            BearObject = collision.gameObject;
            Prompt.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == BearObject)
        {
            BearObject = null;
            Prompt.SetActive(false);
        }
    }
}
