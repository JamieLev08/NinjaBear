using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Coin_Storage coin;


    public int level = 3;

    public void SavePlayer()
    {
        Save_system.savePlayer(this);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "save-player")
        {
            Player_data data = Save_system.LoadPlayer();

            level = data.level;

            Vector2 position;
            position.x = data.position[0];
            position.y = data.position[1];
            transform.position = position;
        }
    }

    public void FixedUpdate()
    {
        
    }

}