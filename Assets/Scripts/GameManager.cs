using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public int ballPerLevel;

    public bool win=false;

    public bool GameOver=false;

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
        Debug.Log(GameObject.FindGameObjectsWithTag("Ball").Length);
        if (GameManager.getInstance.ballPerLevel==0 && GameObject.FindGameObjectsWithTag("Ball").Length==0)
        {
            FindObjectOfType<SceneManage>().nextLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void Update()
    {
        checkWin();
        Debug.Log(win);
    }

    public void newLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void tryAgain()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
