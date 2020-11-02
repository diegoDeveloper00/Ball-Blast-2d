using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;

    public float speed;

    public GameObject bulletPrefab;

   public int firePower;

    public int firePowerTemp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Movement();
        Fire();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -8f, 8f);
        transform.position = pos;
    }

    private void Fire()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity); 
        }
    }
}
