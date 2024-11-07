using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="DetectionAmout",menuName ="DetectionAmount")]
public class DetectionAmount : ScriptableObject
{
    public float DetectionProgress = 0f;
    public bool detected;
    public bool insta_kill = false;
    public float detectionRateUP = 0.0005f;
    public float detectionRateDown = 0.00025f;
    public bool respawn;
}
