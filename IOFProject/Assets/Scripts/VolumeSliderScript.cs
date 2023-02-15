using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class VolumeSliderScript : MonoBehaviour
{

    public AudioMixerGroup group;
    float SliderVolumeLevel;
    public Slider slider;
    
    public void SliderChanged(float value){
        group.audioMixer.SetFloat(group.name,Mathf.Log10(value) * 20);
        
    }
    void SaveSliderVolume()
    {
        PlayerPrefs.SetFloat("SliderVolumeLevel", slider.GetComponent<Slider>().value);
    }
}
