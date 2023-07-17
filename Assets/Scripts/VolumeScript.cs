using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    public Slider volumeSlider;
    private float volume;

    void Start() {
        if (PlayerPrefs.GetFloat("Volume") == 0) {                     
            PlayerPrefs.SetFloat("Volume", 0.5f);
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        } else {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
            //volume = PlayerPrefs.GetFloat("Volume");
        }
    }
    void Update() {
        //volume = volumeSlider.value;
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
