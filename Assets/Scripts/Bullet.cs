using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed;

    public int firePower;
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
            collision.GetComponent<Ball>().TakeDamage(firePower);
            Destroy(this.gameObject);
        }else if(this.gameObject.name.Equals("BossBullet") && collision.GetComponent<Player>())
        {
            collision.GetComponent<Player>().GameOver();
        }
        if (collision.GetComponent<Boss>())
        {
            collision.GetComponent<Boss>().takeDamage(firePower);
        }
        Destroy(this.gameObject, 3f);

    }
}
