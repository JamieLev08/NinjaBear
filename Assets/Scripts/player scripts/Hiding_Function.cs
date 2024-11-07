using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding_Function : MonoBehaviour
{

    
    private SpriteRenderer rend;
    private bool Can_Hide = false;



    public Rigidbody2D rb;
    public LayerMask Test_Object;
    public LayerMask Hidden;
    public Collider2D BodyCollider;
    public new GameObject gameObject;
    public bool Is_Hiding = false;




    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        BodyCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(6, 8);

        // if can hide is equal to true and the "E" button or if on controller "fire2"
        if (Can_Hide == true && Input.GetButton("Fire2"))
        {
            // This will stop the enemies from touching the player when they are hiding  
            Physics2D.IgnoreLayerCollision(8, 10, true);

            // resorts the player to the back of the scene, placing them behind the object 
            rend.sortingOrder = 0;

            // if player is hiding their current tag becomes undetectable, this will be used for the detection system
            gameObject.tag = "Undetectable";

            Debug.Log("Work god damn it");

            // hiding is now active
            Is_Hiding = true;
        }

        // if the above is false the sorting order stays the same and the enemy can now collide with the player
        else
        {
            Physics2D.IgnoreLayerCollision(8, 10, false);
            rend.sortingOrder = 2;
            gameObject.tag = "Player";
            Is_Hiding = false;
        }
    }

    // only allows hiding to be true if the obect is tagged with "Test_Object"
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Test_Object")
        {
            Can_Hide = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Test_Object")
        {
            Can_Hide = false;
        }
    }
}
