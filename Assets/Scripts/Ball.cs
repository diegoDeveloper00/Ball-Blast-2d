using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;

    TextMeshPro textNum;

    [SerializeField]
    int healtNum;

    GameObject[] ballArray;

     float valuePerBall=1f;

    ProgressBar progressBar;

    ParticleSystem groundParticle;

    [SerializeField]
    int scorePerBall;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        textNum=GetComponentInChildren<TextMeshPro>();
        ballArray = FindObjectOfType<BallSpawner>().getBallArray();
        progressBar=FindObjectOfType<ProgressBar>();
        groundParticle = GetComponentInChildren<ParticleSystem>();
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
            FindObjectOfType<Player>().totalScore += scorePerBall;
            if (gameObject.name.Equals("BigBall"))
            {
                Destroy(this.gameObject);
                instantiateMultipleBall(1);

            }
            else if (gameObject.name.Equals("MediumBall"))
            {
                Destroy(this.gameObject);
                instantiateMultipleBall(0);
            }
            else if (gameObject.name.Equals("SmallBall"))
            {
                Destroy(this.gameObject);
                progressBar.increaseSliderValue(valuePerBall);
            }
   
        }
    }

    public void instantiateMultipleBall(int index)
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject temp=Instantiate(ballArray[index], transform.position, Quaternion.identity);
            temp.name = "" + ballArray[index].name + "";
            temp.GetComponent<Ball>().valuePerBall = this.valuePerBall;
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
            groundParticle.Play();
        }
        else if (collision.GetComponent<Player>())
        {
            Player p = collision.GetComponent<Player>();
            p.GameOver();
        }
    }

    public bool isName(string name)
    {
        return name == this.gameObject.name;
    }

    private void OnDisable()
    {
        if (this.gameObject.name.Equals("BigBall"))
        {
            valuePerBall /=(float) 2;
        }
        else if (this.gameObject.name.Equals("MediumBall"))
        {
            valuePerBall /= (float) 2;
        }
    }
}
