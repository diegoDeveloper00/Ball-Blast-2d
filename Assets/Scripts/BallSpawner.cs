using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    int randomVariable;

    Vector2 randomPos;

    int ballQuantity;

    float spawnDelay;

    public GameObject[] balls;

    public int randomIndex;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();

    }

    private void Spawn()
    {
        ballQuantity = Random.Range(1, 3);

         randomIndex= Random.Range(0, balls.Length);

        for (int i = 0; i < ballQuantity; i++)
        {
            randomVariable = Random.Range(-6, 6);
            if (randomVariable >= 0)
            {
                randomPos = new Vector2(6, Random.Range(0, 5));
            }
            else if (randomVariable < 0)
            {
                randomPos = new Vector2(-6, Random.Range(0, 5));
            }
            Instantiate(balls[randomIndex], randomPos, Quaternion.identity);
        }
    }

    public GameObject[] getBallArray()
    {
        return balls;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
