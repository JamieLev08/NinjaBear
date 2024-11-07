using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    /* These are the movements variables that determine how fast the movement is
     * movementSpeed = used as the varaiable for each time the player's speed needs calculating
     * groundedMovementSpeed = used as a variable to set the movementSpeed when on the grounded
     * jumpMovementSpeed = used as a variable to set the movementSpeed when up in the air
     * JumpForce = this is used to claculate how high the player jumps
     * horizontalMovement = a variable that just stores the final movement calculation to then be applied to the players rigidbody
     */
    public float movementSpeed = 2f;
    public float groundedMovementSpeed = 3f;
    public float jumpMovementSpeed = 3f;
    public float JumpForce = 5.5f;
    public float horizontalMovement;

    /* Detect = a variable that stores a shortcut to the scriptable object DetectionAmount so then the player can interact with the detection system
     * layerM = just a variable that is used to make the raycasting only focus on
     */
    public DetectionAmount Detect;
    public checkpointData CPposition;
    public LayerMask layerM;



    // animator = This variable is just a way for the player's animator, so that when the player starts to move it runs the animation
    public Animator animator;

    private Rigidbody2D RB;
    private CapsuleCollider2D capsuleCollider2D;
    public SpriteRenderer SR;

    public CombatUI combatUI;
    
    void Start()
    {
        //This is just a variable to hold the Rigidbody component with the variable name RB
        RB = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// This will update every frame and take the input of the player and added the direction needed
    /// Or if the space bar is pressed add an impluse upwards and then can't jump again until the velocity of the y axis is 0
    /// this would need to change if we want to add a double jump later on.
    /// </summary>
    void Update()
    {
        var movement = Input.GetAxisRaw("Horizontal");
        var movement0 = Input.GetAxis("dPadX");
        Hiding_Function hiding = GetComponent<Hiding_Function>();

        horizontalMovement = movement * movementSpeed;
        animator.SetFloat("Player_Speed", Mathf.Abs(horizontalMovement));
        if (hiding.Is_Hiding == false)
        {
            if (IsRightHit() == false && Input.GetAxisRaw("Horizontal") > 0)
            {
                //SR.flipX = false;
                this.gameObject.transform.localScale = new Vector3(1, 1, 1);
                RightMovement(movement);
            }
            if (IsLeftHit() == false && Input.GetAxisRaw("Horizontal") < 0)
            {
                //SR.flipX = true;
                this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                LeftMovement(movement);
            }
            if(IsRightHit() == false && Input.GetAxis("dPadX") > 0)
            {
                animator.SetFloat("Player_Speed", Mathf.Abs(movementSpeed));
                this.gameObject.transform.localScale = new Vector3(1, 1, 1);
                RightMovement(1);
            }
            if(IsLeftHit() == false && Input.GetAxis("dPadX") < 0)
            {
                animator.SetFloat("Player_Speed", Mathf.Abs(movementSpeed));
                this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
                LeftMovement(-1);
            }
            if (IsGrounded() == true)
            {
                animator.SetBool("isJumping", false);
            }

            if (IsGrounded() == true && Input.GetButtonDown("Jump"))
            {
                RB.velocity = Vector2.up * JumpForce;
            }
            if (IsGrounded() == false)
            {
                animator.SetBool("isJumping", true);
                movementSpeed = jumpMovementSpeed;
            }
            else
            {
                animator.SetBool("isJumping", false);
                movementSpeed = groundedMovementSpeed;
            }
        }
        if (Detect.respawn == true)
        {
            gameObject.tag = "Undetectable";
            combatUI.bulletTime = false;
            animator.SetBool("Death", true);
            groundedMovementSpeed = 0f;
            jumpMovementSpeed = 0f;
            JumpForce = 0;
        }

    }

    void RightMovement(float movement)
    {
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
    }

    void LeftMovement(float movement)
    {

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;
    }

    private bool IsRightHit()
    {
        float extraBuffer = 0.015f;
        RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider2D.bounds.center, Vector2.right, capsuleCollider2D.bounds.extents.x + extraBuffer, layerM);
        Color Raycolor;
        if (raycastHit.collider != null)
        {
            Raycolor = Color.green;
        }
        else
        {
            Raycolor = Color.red;
        }
        Debug.DrawRay(capsuleCollider2D.bounds.center, Vector2.right * (capsuleCollider2D.bounds.extents.x + extraBuffer), Raycolor);
        return raycastHit.collider != null;
    }
    /// <summary>
    /// This is a subroutine that will be used to detect if the raycasting has come into contact with any walls 
    /// when the ray casting does collided with something the subroutine will then 
    /// </summary>
    /// <returns></returns>
    private bool IsLeftHit()
    {
        float extraBuffer = 0.015f;
        RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider2D.bounds.center, Vector2.left, capsuleCollider2D.bounds.extents.x + extraBuffer, layerM);
        Color Raycolor;
        if (raycastHit.collider != null)
        {
            Raycolor = Color.green;
        }
        else
        {
            Raycolor = Color.red;
        }
        Debug.DrawRay(capsuleCollider2D.bounds.center, Vector2.left * (capsuleCollider2D.bounds.extents.x + extraBuffer), Raycolor);
        return raycastHit.collider != null;
    }

    private bool IsGrounded()
    {
        float extraBuffer = 0.075f;
        RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider2D.bounds.center, Vector2.down, capsuleCollider2D.bounds.extents.y + extraBuffer, layerM);
        Color Raycolor;
        if (raycastHit.collider != null)
        {
            Raycolor = Color.green;
        }
        else
        {
            Raycolor = Color.red;
        }
        Debug.DrawRay(capsuleCollider2D.bounds.center, Vector2.down * (capsuleCollider2D.bounds.extents.y + extraBuffer), Raycolor);
        return raycastHit.collider != null;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            Detect.insta_kill = true;
        }
        else
        {
            Detect.insta_kill = false;
        }
    }

    public void Death()
    {
        gameObject.tag = "Player";
        Detect.respawn = false;
        gameObject.transform.position = CPposition.position;
        animator.SetBool("Death", false);
    }

    public void Respawn()
    {
        gameObject.tag = "Undetectable";
    }

    public void EndRespawn()
    {
        Debug.Log("Respawn ended");
        gameObject.tag = "Player";
        groundedMovementSpeed = 3f;
        jumpMovementSpeed = 3f;
        JumpForce = 5.5f;
    }
}
