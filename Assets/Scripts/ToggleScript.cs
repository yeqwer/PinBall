using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScript : MonoBehaviour
{
    public List<GameObject> toggles;
    public List<AudioClip> responseAudioEffect;
    public LightScript lightScript;
    public float flashPower = 8f;

    void Awake() {
        toggles = new List<GameObject>();
        lightScript = FindObjectOfType<LightScript>();
    }

    void Start() {
        toggles.AddRange(GameObject.FindGameObjectsWithTag("Toggle"));
    }

    public void CheckToggle(GameObject toggle) {
        int index = toggles.IndexOf(toggle);
        //Mission
        ShutDownToggle(toggle);
    }

    private void ShutDownToggle(GameObject toggle) {
        toggle.GetComponent<Animator>().SetBool("Active", false);
        
        lightScript.ShutDownLamp(toggle.transform.parent.GetComponentInChildren<Light>());

        var source = toggle.GetComponent<AudioSource>();
        source.clip = responseAudioEffect[Random.Range(0, 1)]; 
        source.Play();
    }

    public void EnablingToggle(GameObject toggle) {
        toggle.GetComponent<Animator>().SetBool("Active", true);
        var source = toggle.GetComponent<AudioSource>();
        source.clip = responseAudioEffect[2]; 
        source.Play();
        lightScript.EnablingLamp(transform.parent.GetComponentInChildren<Light>(), flashPower);
    }
}
