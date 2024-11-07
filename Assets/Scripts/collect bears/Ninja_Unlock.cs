using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja_Unlock : MonoBehaviour
{
    public Bears_SO Bear;
    public GameObject ninjaBear;
    // Start is called before the first frame update
    void Start()
    {
        ninjaBear.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Bear.Teary == true && Bear.Pawl == true && Bear.Nafurn == true)
        {
            ninjaBear.SetActive(true);
        }
        else
        {
            ninjaBear.SetActive(false);
        }
    }
}
