using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public List<GameObject> buttons;
    public LightScript lightScript;
    public ScoreCounterScript scoreCounterScript;
    public List<AudioClip> responseAudioEffect;
    public float flashPower = 20f;
    public float powerLamp = 0f;

    void Awake() {
        buttons = new List<GameObject>();
        lightScript = FindObjectOfType<LightScript>();
        scoreCounterScript = FindObjectOfType<ScoreCounterScript>();
    }

    void Start() {
        buttons.AddRange(GameObject.FindGameObjectsWithTag("Button"));
    }

    public void CheckButton(GameObject butt) {
        int index = buttons.IndexOf(butt);
        
        scoreCounterScript.ButtonCount(index);
        //Mission
        ResponseButton(butt);
    }

    private void ResponseButton(GameObject butt) {
        butt.GetComponent<Animator>().SetTrigger("ResponseButt");
        
        var source = butt.GetComponent<AudioSource>();
        source.clip = responseAudioEffect[Random.Range(0, responseAudioEffect.Count)]; 
        source.Play();

        var lamp = butt.transform.parent.GetComponentInChildren<Light>();
        lightScript.StrobeLamp(lamp, powerLamp, flashPower);
    }
}
