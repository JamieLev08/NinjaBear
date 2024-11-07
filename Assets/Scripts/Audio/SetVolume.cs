using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public audioData audio_Data;
    public Slider slider;

    void Start()
    {
        slider.SetValueWithoutNotify(audio_Data.volume);
        mixer.SetFloat("Volume", Mathf.Log10(slider.value) * 20);
    }

    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20);
        audio_Data.volume = slider.value;
    }
}
