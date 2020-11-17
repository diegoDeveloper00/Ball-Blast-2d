using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePattern : MonoBehaviour
{
    public GameObject bullet;

   float angle;

    int num = 10;

    float startAngle = 90f, endAngle = 270f;

    // Start is called before the first frame update

    // Update is called once per frame

    private void Start()
    {
        InvokeRepeating("fire", 0f, 2f);
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

            angle += angleStep;

            bull.GetComponent<Rigidbody2D>().velocity = new Vector3(bulDir.x, bulDir.y);

        }

    }

}
