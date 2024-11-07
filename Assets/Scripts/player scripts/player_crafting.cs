using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_crafting : MonoBehaviour
{
    [Header("Combat and Crafting")]
    public List<string> items;
    public Transform attackPoint;
    public float attackRange;
    private Collider2D itemCollision;
    public GameObject combatText;
    [Header("Make sure to reference detection scriptable object")]
    public DetectionAmount detectionObject;
    public CombatUI combatUI;
    public Hamme_Parts_Collected hammerParts;
    public GameObject prompt;
    public LayerMask layer;

    /// <summary>
    /// Due to using scriptable objects, I need to reset all of the values as early into the game as possible.
    /// </summary>
    void Awake()
    {
        combatUI.activateUI = false;
        combatUI.bulletTime = false;
        combatUI.pressedButton = false;
    }
    void Update()
    {
        if (items.Contains("handle") && items.Contains("hammerhead"))
        {
            CombatPrompt();
        }
        /// <summary>
        /// Fire3 is Q on PC and "X" on controller.
        /// </summary>
        if (Input.GetButtonUp("Fire3"))
        {
            /// <summary>
            /// This boolean is used so you can press the attack button again while in combat.
            /// </summary>
            combatUI.pressedButton = true;
            if (items.Contains("handle") && items.Contains("hammerhead") && combatUI.bulletTime == false)
            {
                /// <summary>
                /// If the hammer parts are in the list then they can try to attack an enemy.
                /// </summary>
                UseItemWithKey();
            }
        }
        if(combatUI.removeItems == true)
        {
            items.Remove("handle");
            items.Remove("hammerhead");
            if (!items.Contains("handle") && !items.Contains("hammerhead"))
            {
                Debug.Log("All items gone");
            }
            combatUI.removeItems = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /// <summary>
        /// This finds a pickup object and adds it to a list if it is not already in the list.
        /// </summary>
        if (collision.CompareTag("Pickup"))
        {
            if (items.Contains(collision.name))
            {
                Debug.Log("item already in list");
            }
            else
            {
                items.Add(collision.name);
                Destroy(collision.gameObject);
            }
            //these if statements are to make it so that the collected item appear on a UI
            if (collision.name == "hammerhead")
            {
                hammerParts.hammerHead = true;
            }
            if (collision.name == "handle")
            {
                hammerParts.hammerHandle = true;
            }
        }
    }
    /// <summary>
    /// This function creates a collider that checks for an enemy and starts combat.
    /// </summary>
    private void UseItemWithKey()
    {
        Collider2D[] hitArea = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach (Collider2D areaCollision in hitArea)
        {
            if (areaCollision.CompareTag("enemy"))
            {
                /// <summary>
                /// This is the combat state, the idea is you have to hit a sweetspot on the combat bar,
                /// time is slowed to make the player feel like they are in a different state.
                /// </summary>
                combatUI.sweetSpot = Random.Range(0.25f, 0.75f);
                combatUI.currentEnemy = areaCollision.gameObject;
                itemCollision = areaCollision;
                combatUI.bulletTime = true;
                combatUI.activateUI = true;
                Time.timeScale = 0.05f;
            }
        }
    }

    void CombatPrompt()
    {
        Collider2D[] hitArea = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        bool enemyHere = false;
        foreach (Collider2D areaCollision in hitArea)
        {
            if (areaCollision.CompareTag("enemy"))
            {
                enemyHere = true;
                Debug.Log("Yes");
                prompt.SetActive(true);
            }
            else if(areaCollision.tag != "enemy" && enemyHere == false)
            {
                enemyHere = false;
                Debug.Log("Yeaaa");
                prompt.SetActive(false);
            }
        }
    }
}