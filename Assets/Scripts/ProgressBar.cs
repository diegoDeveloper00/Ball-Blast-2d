using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;

    public float value;

   public int target=3;

    BallSpawner ballSpawner;

    Text[] texts;

    int actualLevel;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        ballSpawner = FindObjectOfType<BallSpawner>();
        target = GameManager.getInstance.ballPerLevel;
        slider.maxValue = target;
        texts = GetComponentsInChildren<Text>();
        actualLevel = SceneManager.GetActiveScene().buildIndex;
        texts[0].text = "" + actualLevel;
        texts[1].text = "" +( actualLevel+1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void increaseSliderValue(float value)
    {
        if (slider.value < target)
        {
            slider.value += value;
        }
    }
}
