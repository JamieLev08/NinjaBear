using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pauseFirstButton, trophyFirstButton, settingsFirstButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPauseMenu()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object 
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void OpenTrophyMenu()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object 
        EventSystem.current.SetSelectedGameObject(trophyFirstButton);
    }
    public void OpenSettingsMenu()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object 
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);
    }
}
