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
    public float moveSpeed = 5f;
    public float jumpForce = 10f; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 20f;
            Debug.Log("E");
        }
        else
        {
            moveSpeed = 5f;
        }
        movementValueX = Input.GetAxis("Horizontal");
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, 0f, whatIsGround);
        rb.velocity = new Vector2(movementValueX * moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }
}
