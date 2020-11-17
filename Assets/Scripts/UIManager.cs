using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Text scoreText;
    
    [SerializeField]
    Text bestScoreText;

    [SerializeField]
    GameObject gameOverText;

    Player player;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.SetActive(false);
        scoreText = GetComponentInChildren<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.getInstance.GameOver)
        {
            gameOverText.SetActive(true);
            score = 0;
        }
        else
        {

            gameOverText.SetActive(false);
        }

        updateHighScore();
        
    }

    private void Awake()
    {
        UIManager[] objs = FindObjectsOfType<UIManager>();
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void updateScore(int Playerscore)
    {
       
        score += Playerscore;
        scoreText.text = "" + score;
    }

    public void updateHighScore()
    {
        bestScoreText.text = "" + PlayerPrefs.GetInt("HighScore");
        if (score >= PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            bestScoreText.text = "" + score;
        }
       
    }

}
