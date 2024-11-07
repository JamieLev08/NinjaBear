using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class scene_change : MonoBehaviour
{
    GameObject[] Gamemaster;
    public static bool gameIsPaused;
    public Coin_List_Maker coin_List_Maker;
    public timerData timer_Data;
        


        //the following allows the program to load another scene.
    public void LoadScene(string scenename)
    {

        SceneManager.LoadScene(scenename);
        PlayerPrefs.Save();
        if (scenename == "Level_1")
        {
            timer_Data.time = 0;
            timer_Data.start = false;
            PlayerPrefs.SetInt("displayTextCoin", 0);
        }
    }



    // This Function is respobsible for all scene changes across the gmame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // This statement changes the scene on collision with the 'teleporter'. 
        // same goes for following statements below
        if (collision.gameObject.tag == "Enter-Easter_Egg")
        {
            coin_List_Maker.Save();
            SceneManager.LoadScene("Easter_Egg_1");      
        }
        
        if (collision.gameObject.tag == "Enter_Level_1")
        {
            if (SceneManager.GetActiveScene().name != "Easter_Egg_1")
            {
                coin_List_Maker.Clear();
                timer_Data.time = 0;
                timer_Data.start = false;
            }
            SceneManager.LoadScene("Level_1");
        }

        if (collision.gameObject.tag == "Enter_Level_2")
        {
            if(SceneManager.GetActiveScene().name != "Easter_Egg_2")
            {
                coin_List_Maker.Clear();
            }
            PlayerPrefs.SetInt("level2_unlock",1);
            SceneManager.LoadScene("Level_2");
            PlayerPrefs.SetInt("displayTextCoin", 0);
        }
        if (collision.gameObject.tag == "Enter_Level_1_Tutorial")
        {
            coin_List_Maker.Clear();
            SceneManager.LoadScene("Level_1");
        }
        if (collision.gameObject.tag == "Enter-Easter_Egg_2")
        {
            coin_List_Maker.Save();
            SceneManager.LoadScene("Easter_Egg_2");
        }
        if (collision.gameObject.tag == "Enter_level_3")
        {
            if (SceneManager.GetActiveScene().name != "Easter_Egg_3")
            {
                coin_List_Maker.Clear();
            }
            PlayerPrefs.SetInt("level3_unlock", 1);
            SceneManager.LoadScene("Level_3");
            PlayerPrefs.SetInt("displayTextCoin", 0);
        }
        if (collision.gameObject.tag == "Enter_EasterEgg_3")
        {
            coin_List_Maker.Save();
            SceneManager.LoadScene("Easter_Egg_3");
        }
        if(collision.gameObject.tag == "end")
        {
            coin_List_Maker.Clear();
            SceneManager.LoadScene("Credits");
        }
        return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water_death")
        {
            SceneManager.LoadScene("Easter_Egg_1");
        }

        if (collision.gameObject.tag == "Space_death")
        {
            SceneManager.LoadScene("Easter_Egg_3");
        }
    }
}