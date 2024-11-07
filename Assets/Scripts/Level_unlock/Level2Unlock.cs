using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Unlock : MonoBehaviour
{
    public int level2int;

    // Update is called once per frame
    void Update()
    {
        level2int = PlayerPrefs.GetInt("level2_unlock");
        if (level2int == 1)
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
