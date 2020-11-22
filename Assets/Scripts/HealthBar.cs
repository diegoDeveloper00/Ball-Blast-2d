using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;

    Boss boss;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        boss = FindObjectOfType<Boss>();
        slider.maxValue = boss.maxHealth;
        slider.value = boss.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().anchoredPosition = boss.transform.position;
    }
    public void setCurrentHealth(int currentHealt)
    {
        slider.value = currentHealt;
    }

}
