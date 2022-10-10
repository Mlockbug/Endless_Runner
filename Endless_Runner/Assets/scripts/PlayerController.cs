using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text scoreText;
    int score = 0;
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
    public Animator anim;
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
        isOnGround = Physics2D.OverlapCircle(groundCheck.transform.position, 0f, whatIsGround);

        if (rb.velocity.y == 0)
        {
            anim.SetBool("OnGround", true);
        }
        else
        {
            anim.SetBool("OnGround", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            anim.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = true;
            movementValueX = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            anim.SetTrigger("SecondJump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = false;
            movementValueX = 0f;
        }
        else if (isOnGround)
        {
            Debug.Log("E");
            doubleJump = true;
        }
        else if (isOnGround)
        {
            anim.ResetTrigger("Jump");
            anim.ResetTrigger("SecondJump");
        }
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        anim.SetFloat("Falling", rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "bronze":
                score += 1;
                scoreText.text = "Score: " + score.ToString();
                break;
            case "silver":
                score += 3;
                scoreText.text = "Score: " + score.ToString();
                break;
            case "gold":
                score += 5;
                scoreText.text = "Score: " + score.ToString();
                break;
            default:
                break;
        }
        Destroy(collision.gameObject);
    }
}
