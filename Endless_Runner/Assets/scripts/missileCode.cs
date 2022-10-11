using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileCode : MonoBehaviour
{

    public Rigidbody2D missile;
    GameObject player; 
    private bool alive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            missile.velocity = new Vector2(-3f, 0f);
        }
    }

    void Awake()
    {
        alive = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "ground":
                Destroy(gameObject);
                break;
            case "shuriken":
                player.GetComponent<PlayerController>().scoreMissile();
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
        }
    }
}
