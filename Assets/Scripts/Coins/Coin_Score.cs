using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Score : MonoBehaviour
{
    public Text displayTextCoin;
    public Coin_Storage coinsCollected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayTextCoin.text = "Score: " + (coinsCollected.coinAmount * 100).ToString("0");
    }
}
