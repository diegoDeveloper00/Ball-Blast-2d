using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    int randomVariable;

    Vector2 randomPos;

    int ballQuantity;

    float spawnDelay;

    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ballQuantity = Random.Range(1, 3);

        for(int i = 0; i < ballQuantity; i++)
        {
            randomVariable = Random.Range(-8, 8);
            if (randomVariable >= 0)
            {
                randomPos = new Vector2(8, Random.Range(0, 5));
            }
            else if (randomVariable < 0)
            {
                randomPos = new Vector2(-8, Random.Range(0, 5));
            }
            Instantiate(ball, randomPos, Quaternion.identity);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
