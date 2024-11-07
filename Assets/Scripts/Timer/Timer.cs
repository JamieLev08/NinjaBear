using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float time;
    public Text text;
    public GameObject textObj;
    public timerData timer_Data;
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        if(timer_Data.start == false)
        {
            Debug.Log("Here");
            timer_Data.time = 0;
        }
        if(SceneManager.GetActiveScene().name == "main menu")
        {
            toggle.isOn = timer_Data.uiToggle;
            timer_Data.time = 0;
            timer_Data.start = false;
        }
        time = timer_Data.time;
        if(timer_Data.uiToggle == true)
        {
            if(text != null)
            {
                textObj.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer_Data.start == true)
        {
            time += Time.deltaTime;
            float temp = (Mathf.Round(time * 100) / 100);
            timer_Data.time = temp;
            text.text = temp.ToString();
        }
    }

    public void ToggleUI()
    {
        if(toggle.isOn == true)
        {
            timer_Data.uiToggle = true;
        }
        else
        {
            timer_Data.uiToggle = false;
        }
    }

    public void OnApplicationQuit()
    {
        Debug.Log("Here2");
        timer_Data.start = false;
    }
}
