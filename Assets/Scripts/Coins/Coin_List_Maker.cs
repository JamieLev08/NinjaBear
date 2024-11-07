using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_List_Maker : MonoBehaviour
{
    public SO_Test coin_list;
    public List<GameObject> test;
    public List<bool> coinBools;

    void Start()
    {
        test = new List<GameObject>();
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Coin"))
        {
            test.Add(fooObj);
            //coin_list.coinOBJ.Add();
        }
        if (coin_list.coin.Count > 0)
        {
            for (int i = 0; i < test.Count; i++)
            {
                test[i].SetActive(coin_list.coin[i]);
            }
        }
        if (coinBools.Count < test.Count)
        {
            foreach (GameObject coins in test)
            {
                coinBools.Add(coins.activeSelf);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateCoin()
    {
        if (coinBools.Count == test.Count)
        {
            for (int i = 0; i < test.Count; i++)
            {
                coinBools[i] = test[i].activeSelf;
            }
        }
    }

    public void Save()
    {
        coin_list.coin.Clear();
        for (int i = 0; i < coinBools.Count; i++)
        {
            coin_list.coin.Add(coinBools[i]);
        }
    }

    public void Clear()
    {
        coin_list.coin.Clear();
    }
}
