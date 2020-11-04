using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rb.velocity.x,bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<Ball>())
        {
            collision.GetComponent<Ball>().TakeDamage(1);
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject, 3f);

    }
}
