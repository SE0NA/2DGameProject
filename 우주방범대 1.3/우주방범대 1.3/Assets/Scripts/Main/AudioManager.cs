using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public enum SliderOption
{
    MASTER, BGM, SFX
}

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer = null;
    public Slider slider = null;

    public SliderOption currentSlider;

    void Start()
    {
        switch (currentSlider)
        {
            case SliderOption.MASTER:
                slider.value = PlayerPrefs.GetFloat("AudioMaster");
                break;
            case SliderOption.BGM:
                slider.value = PlayerPrefs.GetFloat("AudioBGM");
                break;
            case SliderOption.SFX:
                slider.value = PlayerPrefs.GetFloat("AudioSFX");
                break;
        }

    }

    public void AudioControl()
    {
        float sound = slider.value;
        switch (currentSlider)
        {
            case SliderOption.MASTER:
                if (sound == -40f) sound = -80f;
                audioMixer.SetFloat("Master", sound);
                PlayerPrefs.SetFloat("AudioMaster", sound);
                break;

            case SliderOption.BGM:
                if (sound == -40f) sound = -80f;
                audioMixer.SetFloat("BGM", sound);
                PlayerPrefs.SetFloat("AudioBGM", sound);
                break;

            case SliderOption.SFX:
                if (sound == -40f) sound = -80f;
                audioMixer.SetFloat("SFX", sound);
                PlayerPrefs.SetFloat("AudioSFX", sound);
                break;
        }
    }
}
