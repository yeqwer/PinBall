using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetupScript : MonoBehaviour
{
    public List<AudioSource> audios;
    void Awake() {
        audios = new List<AudioSource>();
    }
    void Start() {
        audios.AddRange(FindObjectsOfType<AudioSource>());

        foreach (AudioSource source in audios) {
            source.playOnAwake = false;
            source.spatialBlend = 0;
            source.dopplerLevel = 0;
            source.rolloffMode = AudioRolloffMode.Linear;
            source.minDistance = 495;
        }
    }
}
