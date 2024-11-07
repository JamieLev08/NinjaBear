using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collected_Bears_Check : MonoBehaviour
{
    public Bears_SO Bears;
    public Image Teary;
    public Image Pawl;
    public Image Nafurn;

    private void Start()
    {
        if (Bears.Teary == false)
        {
            Teary.enabled = false;
        }
        if (Bears.Pawl == false)
        {
            Pawl.enabled = false;
        }
        if (Bears.Nafurn == false)
        {
            Nafurn.enabled = false;
        }
    }

    void Update()
    {
        if (Bears.Teary == true)
        {
            Teary.enabled = true;
        }
        if (Bears.Pawl == true)
        {
            Pawl.enabled = true;
        }
        if (Bears.Nafurn == true)
        {
            Nafurn.enabled = true;
        }
    }
}
