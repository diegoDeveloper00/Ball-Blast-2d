﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;

    Animator anim;

    public float speed;

    public GameObject bulletPrefab;


    public int firePowerTemp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManager.getInstance.GameOver) { return; }
        else if (!GameManager.getInstance.GameOver)
        {
            Movement();
            Fire();
        }
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
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
                Instantiate(bulletPrefab, transform.position, Quaternion.identity); 
        }
    }

    public void GameOver()
    {
        anim.SetBool("Death", true);
       rb.velocity=new Vector2(0,0f);
        GameManager.getInstance.GameOver = true;
    }

}
