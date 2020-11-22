using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 pos;

    float bossSpeed = 3f;

    public GameObject bullet;

    float angle;

    int num = 10;

    float startAngle = 90f, endAngle = 270f;

    public int maxHealth = 100;

    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = Vector2.right;
        InvokeRepeating("fire", 2f, 2f);
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = pos * bossSpeed;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("WallRight"))
        {
            pos = Vector2.left;
        }else if (collision.gameObject.name.Equals("WallLeft"))
        {
           pos = Vector2.right;
        }
    }

    public void fire()
    {
        float angleStep = (endAngle - startAngle) / num;
        angle = startAngle;

        for (int i = 0; i < num; i++)
        {

            float dirX = transform.position.x + Mathf.Sin((angle * Mathf.PI / 180));
            float dirY = transform.position.y + Mathf.Cos((angle * Mathf.PI / 180));

            Vector2 bullTransform = new Vector2(dirX, dirY);

            Vector2 bulDir = (bullTransform - (Vector2)transform.position).normalized * 3;

            GameObject bull = Instantiate(bullet, transform.position, Quaternion.identity);

            bull.name = ""+bullet.name;

            angle += angleStep;

            bull.GetComponent<Rigidbody2D>().velocity = new Vector3(bulDir.x, bulDir.y);

        }

    }

    public void takeDamage(int firePower)
    {
        currentHealth -= firePower;
        healthBar.setCurrentHealth(currentHealth);
    }

}
