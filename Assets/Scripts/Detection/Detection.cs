using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public DetectionAmount Detect;
    public string TagName = "Detected";
    public string TagName2 = "Untagged";
    public new GameObject gameObject;
    public bool undetect = false;
    public Sprite ogsprite;
    public Sprite ogsprite2;

    GameObject[] undetectable;

    private void Start()
    {
        Detect.detected = false;
        undetect = true;
    }
    void Update()
    {
        undetectable = GameObject.FindGameObjectsWithTag("Undetectable");
        foreach (GameObject g in undetectable)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = ogsprite2;
            Detect.detected = false;
        }
    }

    //Overlapping a collider 2D
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Detect.detected = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = ogsprite;

            
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Detect.detected = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = ogsprite2;

        }
        if (collision.CompareTag("wall"))
        {
            gameObject.tag = "Untagged";
        }
    }

}
