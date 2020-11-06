using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public int ballPerLevel;

    public bool win;

    public static GameManager getInstance
    {
        get{
            if (instance == null)
            {
                Debug.LogError("instance no present");
            }
            return instance;
        }

    }

    private void Awake()
    {
        instance = this;
    }

    public void checkWin()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length==0)
        {
            win = true;
        }
    }

}
