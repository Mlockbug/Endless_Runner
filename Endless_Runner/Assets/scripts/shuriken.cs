using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shuriken : MonoBehaviour
{
    bool alive = false;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            rb.velocity = new Vector2(10f, 0f);
            rb.rotation -= 1.0f;
        }
    }

    private void Awake()
    {
        alive = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }
    }
}
