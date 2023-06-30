using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackgroundScript : MonoBehaviour 
{
    public AudioClip[] clips;
    private AudioSource audioSource;
    public bool randomPlay = false;
    public int clipOrder = 0;
    public float volume = 0.2f;

    void Awake() {
        audioSource = GameObject.FindGameObjectWithTag("AudioBackground").GetComponent<AudioSource>();
        DontDestroyOnLoad(transform.gameObject);
    } 

    void Start() {
    audioSource = GetComponent<AudioSource> ();
    audioSource.loop = false;
    }

    void Update () {
        if (!audioSource.isPlaying) {

            if (randomPlay == true) {
                audioSource.clip = GetRandomClip ();
                audioSource.Play ();

            } else {
                audioSource.clip = GetNextClip ();
                audioSource.Play ();
            }
        }
        audioSource.volume = volume;
    }

    private AudioClip GetRandomClip() {
        return clips[Random.Range (0, clips.Length)];
    }

    private AudioClip GetNextClip() {
        if (clipOrder >= clips.Length - 1) {
            clipOrder = 0;
        } else {
            clipOrder += 1;
        }
        return clips[clipOrder];
    }
}