using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_saves : MonoBehaviour
{
    GameObject[] Gamemaster;
    public static bool gameIsPaused;




    //the following allows the program to load another scene.
    public void LoadScene(string scenename)
    {
        Debug.Log(scenename);
        SceneManager.LoadScene(scenename);
    }



    // This Function is respobsible for all scene changes across the gmame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // This statement changes the scene on collision with the 'teleporter'. 
        // same goes for following statements below
        if (collision.gameObject.tag == "Enter_2nd")
        {
            SceneManager.LoadScene("2nd");
        }
    }

    private void gamesave()
    {
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainMenu");
    }
}
