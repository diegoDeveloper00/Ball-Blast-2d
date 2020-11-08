using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    Animator anim;

    int levelToLoad;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void nextLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        anim.SetTrigger("FadeOut");
        
    }

    public void fadeNextLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void creditScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
