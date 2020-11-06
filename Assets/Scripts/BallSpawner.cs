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

        InvokeRepeating("Spawn",0f, Random.Range(3, 10));
    }

    private void Spawn()
    {
        ballQuantity = Random.Range(1, 3);

         randomIndex = Random.Range(0, balls.Length);

        if (GameManager.getInstance.ballPerLevel == 1)
        {
            ballQuantity = 1;
        }

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
            GameObject temp=Instantiate(balls[randomIndex], randomPos, Quaternion.identity);
            randomPos.x += 2;
            temp.name = "" + balls[randomIndex].name + "";
        }
        GameManager.getInstance.ballPerLevel-=ballQuantity;
    }

    public GameObject[] getBallArray()
    {
        return balls;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.getInstance.ballPerLevel <= 0) { CancelInvoke("Spawn"); }
        GameManager.getInstance.checkWin();
    }
}
