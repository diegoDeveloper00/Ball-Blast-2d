using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (transform.position.x > 0)
        {
            rb.velocity = Vector2.left;
        }
        else
        {
            rb.velocity = Vector2.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("WallRight"))
        {
            rb.velocity = Vector2.left;
        }
        else if (collision.gameObject.name.Equals("WallLeft"))
        {
            rb.velocity = Vector2.right;
        }
        else if (collision.gameObject.name.Equals("Ground"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
        }
        Debug.Log(rb.velocity);
    }

}
