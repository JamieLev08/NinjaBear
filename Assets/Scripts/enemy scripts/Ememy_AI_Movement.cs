using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ememy_AI_Movement : MonoBehaviour
{
    public float walkingSpeed;

    public bool Patrol;

    public LayerMask Wall_flip;

    public Rigidbody2D rb;

    public Collider2D bodyCollider;

    public BoxCollider2D boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        Patrol = true;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Patrol)
        {
            patrol();
        }
    }

    private void FixedUpdate()
    {
        if (IsWallFlipHit() )
        {
            flip();
        }
    }

    void patrol()
    {
        Patrol = true;
        rb.velocity = new Vector2(walkingSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    public void flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkingSpeed *= -1;
    }

    private bool IsWallFlipHit()
    {
        float extraBuffer = 0.015f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.right, boxCollider.bounds.extents.x + extraBuffer, Wall_flip);
        Color Raycolor;
        if (raycastHit.collider != null)
        {
            Raycolor = Color.green;
        }
        else
        {
            Raycolor = Color.red;
        }
        Debug.DrawRay(boxCollider.bounds.center, Vector2.right * (boxCollider.bounds.extents.x + extraBuffer), Raycolor);
        return raycastHit.collider != null;
    }


}

