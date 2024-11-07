 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Game : MonoBehaviour
{
	GameObject[] pauseObjects;
	public static bool gameIsPaused;
	public CombatUI combat;
	void Start()
	{
		Time.timeScale = 1;
		//groups together all objects in the pause menu
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
	}    

	void Update()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			if (gameIsPaused == true)
			{
				ResumeGame();
			}
			else
			{
				PauseGame();
			}
		}
	}

	//pauses game if esc is pressed
	void PauseGame()
	{
        combat.bulletTime = true;
        Time.timeScale = 0;
		showPaused();
		gameIsPaused = true;
	}

	//unpauses game if esc is pressed
	void ResumeGame()
    {
		combat.bulletTime = false;
        Time.timeScale = 1;
		hidePaused();
		gameIsPaused = false;

	}

	//shows objects with ShowOnPause tag
	public void showPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}


}