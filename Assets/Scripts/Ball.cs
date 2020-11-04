using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;

    TextMeshPro textNum;

    [SerializeField]
    int healtNum;

    GameObject[] ballArray;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        textNum=GetComponentInChildren<TextMeshPro>();
        ballArray = FindObjectOfType<BallSpawner>().getBallArray();
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
        UpdateBallUI(healtNum);
    }

    private void UpdateBallUI(int healtAmount)
    {
        textNum.text = "" + healtAmount;
    }

    public void TakeDamage(int damage)
    {
        healtNum -= damage;
        if (healtNum == 0)
        {
            if (gameObject.CompareTag("BigBall"))
            {
                Destroy(this.gameObject);
                instantiateMultipleBall(1);

            }else if (gameObject.CompareTag("MediumBall"))
            {
                Destroy(this.gameObject);
                instantiateMultipleBall(0);
            }
            Destroy(this.gameObject);
        }
    }

    public void instantiateMultipleBall(int index)
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(ballArray[index], transform.position, Quaternion.identity);
            transform.position = new Vector2(transform.position.x+2,transform.position.y);
        }
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
        else if (collision.gameObject.name.Equals("Player"))
        {
            collision.GetComponent<Animator>().SetBool("Death", true);
        }
        Debug.Log(rb.velocity);
    }

}
