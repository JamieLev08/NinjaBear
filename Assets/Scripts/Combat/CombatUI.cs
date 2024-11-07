using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "combatUIEnemy", menuName ="CombatUI")]
public class CombatUI : ScriptableObject
{
    public bool activateUI = false;

    public bool bulletTime = false;

    public bool pressedButton = false;

    public float sweetSpot;

    public GameObject currentEnemy;

    public bool removeItems = false;
}
