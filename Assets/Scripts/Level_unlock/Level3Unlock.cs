using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3Unlock : MonoBehaviour
{
    public int level3int;

    // Update is called once per frame
    void Update()
    {
        level3int = PlayerPrefs.GetInt("level3_unlock");
        if (level3int == 1)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
