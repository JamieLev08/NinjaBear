using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
   
    public DetectionAmount DetectRate;
    public Slider slider;
    public Text displayText;
    public CombatUI combatUI;
    public float multiplyer = 0;
    // Create a property to handle the slider's value
    void Start()
    {
        //resets the slider
        DetectRate.DetectionProgress = 0f;     
    }

    void FixedUpdate()
    {
        if (DetectRate.detected == true)
        {
            DetectRate.DetectionProgress += DetectRate.detectionRateUP + multiplyer;
        }
        else if (DetectRate.DetectionProgress >0)
        {
            DetectRate.DetectionProgress -= DetectRate.detectionRateDown;
        }
        else
        {
            DetectRate.DetectionProgress = 0;
        }
        slider.value = DetectRate.DetectionProgress;
        displayText.text = (slider.value * 100).ToString("0.00") + "%";
        if (DetectRate.insta_kill == true)
        {
            DetectRate.detected = false;
            DetectRate.DetectionProgress = 1.1f;
            DetectRate.respawn = true;
        }
        if (DetectRate.DetectionProgress >= 1)
        {
            combatUI.bulletTime = false;
            DetectRate.detected = false;
            DetectRate.insta_kill = false;
            DetectRate.respawn = true;
            DetectRate.DetectionProgress = 0f;
        }    
    }
}