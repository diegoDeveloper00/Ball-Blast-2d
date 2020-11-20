using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setVolume()
    {
        float sliderValue = slider.value;
        FindObjectOfType<AudioManager>().GetComponent<AudioSource>().volume = sliderValue;
        PlayerPrefs.SetFloat("volume", sliderValue);
        if (FindObjectOfType<AudioManager>().GetComponent<AudioSource>().volume == 0)
        {
            FindObjectOfType<ToggleHandler>().GetComponent<Toggle>().isOn = true;
        }
        else
        {
            FindObjectOfType<ToggleHandler>().GetComponent<Toggle>().isOn = false;
        }
    }
}

