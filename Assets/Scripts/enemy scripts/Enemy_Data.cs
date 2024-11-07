using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Data : MonoBehaviour
{
    public CombatUI combatUIVar;
    public GameObject combatSlider;
    public Image barFill;
    public Image filledBar;
    public Slider combatBar;
    public float sweetspotSpeed;
    public float sweetSpotLength;
    public DetectionAmount detectionObject;
    private bool barFlip = false;
    public Transform playerPos;
    private Ememy_AI_Movement movement;
    public Slider randomValuePosition;
    public Hamme_Parts_Collected hammerParts;

    void Start()
    {
        ///<summary>
        /// I get access to the enemy AI movement component so I don't need to use a public variable
        ///</summary>
        movement = gameObject.GetComponent<Ememy_AI_Movement>();
    }
    /// <summary>
    /// This function is called once per frame and is used to check for the player's second input while in the combat state
    /// </summary>
    void Update()
    {
        if (combatUIVar.pressedButton == true && combatUIVar.bulletTime == true)
        {
            combatSlider.SetActive(true);
            randomValuePosition.gameObject.SetActive(true);
            if (Input.GetButtonDown("Fire3"))
            {
                combatUIVar.pressedButton = false;
                if (combatUIVar.sweetSpot - sweetSpotLength < combatBar.value && combatBar.value < combatUIVar.sweetSpot + sweetSpotLength)
                {
                    /// if the player hits the enemy then destroy the object and exit the combat state
                    PlayerExitBulletTime();
                    combatUIVar.removeItems = true;
                    Destroy(combatUIVar.currentEnemy);
                    hammerParts.hammerHandle = false;
                    hammerParts.hammerHead = false;
                }
                else
                {
                    /// if the player misses the sweetspot, make the enemy turn to the player and respawn
                    if (playerPos.position.x < gameObject.transform.position.x)
                    {
                        if (gameObject.transform.localScale.x == 1)
                        {
                            movement.flip();
                        }
                    }
                    else if (playerPos.position.x >= gameObject.transform.position.x)
                    {
                        if (gameObject.transform.localScale.x == -1)
                        {
                            movement.flip();
                        }
                    }
                    PlayerExitBulletTime();
                    detectionObject.detected = false;
                    detectionObject.respawn = true;
                    detectionObject.DetectionProgress = 0;
                }
            }
        }
        /// this is a bug fix to that the combat UI is always running when the state is active
        /// if it isn't then exit the state
        if (combatUIVar.bulletTime == true)
        {
            BulletTimeUI();
        }
        else
        {
            PlayerExitBulletTime();
            randomValuePosition.gameObject.SetActive(false);
            combatBar.value = 0;
        }
        /// the next two if statements are to go through any instance which would need to exit bullet time such as dying instantly(colliding with the enemy)
        /// or if bullet time is deactivated at all for whatever reason
        if (detectionObject.insta_kill == true)
        {
            PlayerExitBulletTime();
        }
        if (combatUIVar.bulletTime == false)
        {
            PlayerExitBulletTime();
        }
        /// This is the ultimate check if the time is normal then no combat UI should be active at all.
        if (Time.timeScale == 1)
        {
            combatSlider.SetActive(false);
            randomValuePosition.gameObject.SetActive(false);
            combatUIVar.bulletTime = false;
            combatBar.value = 0;
        }
    }
    /// <summary>
    /// This function stops the combat state and removes the combat UI
    /// </summary>
    private void PlayerExitBulletTime()
    {
        combatSlider.SetActive(false);
        Time.timeScale = 1;
        combatBar.value = 0;
    }
    /// <summary>
    /// This function starts the UI in the run time,
    /// it also deals with the green bar that moves up and down.
    /// </summary>
    private void BulletTimeUI()
    {
        randomValuePosition.value = combatUIVar.sweetSpot;
        if (barFlip == true)
        {
            combatBar.value -= Time.deltaTime * sweetspotSpeed;
        }
        else
        {
            combatBar.value += Time.deltaTime * sweetspotSpeed;
        }
        if (combatBar.value == 1)
        {
            barFlip = true;
        }
        else if (combatBar.value == 0)
        {
            barFlip = false;
        }
    }
}
