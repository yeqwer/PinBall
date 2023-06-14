using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public List<GameObject> buttons;
    public LightScript lightScript;
    public ScoreCounterScript scoreCounterScript;
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
        
        var lamp = butt.transform.parent.GetComponentInChildren<Light>();
        lightScript.StrobeLamp(lamp, powerLamp, flashPower);
    }
}
