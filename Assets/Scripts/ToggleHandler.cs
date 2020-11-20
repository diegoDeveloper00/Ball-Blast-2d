using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHandler : MonoBehaviour
{
    Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();

        toggle.onValueChanged.AddListener(delegate { ToggleValueChanged(toggle); });

    }

    public void ToggleValueChanged(Toggle toggle)
    {
        if (!toggle.isOn)
        {
            FindObjectOfType<AudioManager>().GetComponent<AudioSource>().volume = 1;
            FindObjectOfType<Volume>().GetComponent<Slider>().value = 1;
        }
        else
        {
            FindObjectOfType<AudioManager>().GetComponent<AudioSource>().volume = 0;
            FindObjectOfType<Volume>().GetComponent<Slider>().value = 0;
        }
    }
}
