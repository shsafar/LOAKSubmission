using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public Slider volumeslider = null;
   
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 5);

        volumeslider.value = PlayerPrefs.GetFloat("volume", AudioListener.volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Audio_Button(float volume)
    {
        AudioListener.volume = volume;

        PlayerPrefs.SetFloat("volume", AudioListener.volume);
    }
}
