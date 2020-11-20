using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{ 
    private void Awake()
    {
        AudioManager[] audioObjs = FindObjectsOfType<AudioManager>();

        if (audioObjs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }

    private void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");

    }

}
