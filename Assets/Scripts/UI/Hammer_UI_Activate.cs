using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hammer_UI_Activate : MonoBehaviour
{

    public Hamme_Parts_Collected hammerActivate;
    public GameObject Hammer_Handle;
    public GameObject Hammer_Head;

    private void Start()
    {
        hammerActivate.hammerHead = false;
        hammerActivate.hammerHandle = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (hammerActivate.hammerHandle == true)
        {
            Hammer_Handle.SetActive(true);
        }
        else
        {
            Hammer_Handle.SetActive(false);
        }
        if (hammerActivate.hammerHead == true)
        {
            Hammer_Head.SetActive(true);
        }
        else
        {
            Hammer_Head.SetActive(false);
        }
    }
}
