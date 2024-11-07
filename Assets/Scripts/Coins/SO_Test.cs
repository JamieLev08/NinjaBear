using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="coin_List",menuName ="Coin_List")]
public class SO_Test : ScriptableObject
{
    public List<bool> coin;
    public List<GameObject> coinOBJ;
}
