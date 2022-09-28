using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject groundCheck;
    public LayerMask whatIsGround;
    bool isOnGround = false;
    float movementValueX;
    public float nonSprintSpeed = 5f;
    public float sprintSpeed = 10f;
    float moveSpeed;
    public float jumpForce = 10f;
    bool doubleJump = true;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = nonSprintSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.LeftShift) && isOnGround)
        {
            moveSpeed = sprintSpeed;
            //Debug.Log(moveSpeed);
        }
        else
        {
            moveSpeed = nonSprintSpeed;
            //Debug.Log(moveSpeed);
        }*/
        movementValueX = 1f;
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, 0.1f, whatIsGround);
        
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = true;
            movementValueX = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = false;
            movementValueX = 0f;
        }
        else if (isOnGround)
        {
            doubleJump = true;
        }
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "coin")
        {
            //add check to type of coin
        }
    }
}
