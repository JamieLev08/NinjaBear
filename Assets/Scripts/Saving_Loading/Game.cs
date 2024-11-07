using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game
{
    public static Game current;
    public Character player;
    public Character enemy;

    public Game()
    {
        player = new Character();
        enemy = new Character();
    }
}
