using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public ForGame game;
    public Slider slider;
    float lastValue;


    void Start()
    {
        game.GetComponent<AudioSource>().volume = lastValue;
        if (PlayerPrefs.HasKey("SoundValue"))
        {
            lastValue = PlayerPrefs.GetFloat("SoundValue");
            slider.value = lastValue;
            game.GetComponent<AudioSource>().volume = slider.value;
        }
    }
    public void SoundValue()
    {

        game.GetComponent<AudioSource>().volume = slider.value;
        lastValue = slider.value;
        Save("SoundValue", lastValue);
    }
    void Save(string name, float value)
    {
        PlayerPrefs.SetFloat(name, value);
        PlayerPrefs.Save();
    }
}
