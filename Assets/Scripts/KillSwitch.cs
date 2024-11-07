using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSwitch : MonoBehaviour
{
    public Coin_Storage coin;
    public Bears_SO Bear;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            Debug.Log("aaaah");
            PlayerPrefs.SetInt("level2_unlock", 0);
            PlayerPrefs.SetInt("level3_unlock", 0);
            coin.coinAmount = 0;
            Bear.Teary = false;
            Bear.Pawl = false;
            Bear.Nafurn = false;
        }

    }
}
