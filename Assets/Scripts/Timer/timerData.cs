using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "timer_Data", menuName = "timer")]
public class timerData : ScriptableObject
{
    public float time;
    public bool start;
    public bool uiToggle;
}
