using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperScript : MonoBehaviour
{
    public List<GameObject> bumpers;
    public LightScript lightScript;
    public ScoreCounterScript scoreCounterScript;
    public float powerLamp = 8f;

    public float flashPower = 20f;

    void Awake() {
        bumpers = new List<GameObject>();
        lightScript = FindObjectOfType<LightScript>();
        scoreCounterScript = FindObjectOfType<ScoreCounterScript>();
    }

    void Start() {
        bumpers.AddRange(GameObject.FindGameObjectsWithTag("Bumper"));
    }

    public void CheckBumper(GameObject bump) {
        int index = bumpers.IndexOf(bump);
        scoreCounterScript.BumperCount(index);

        //Mission
        ResponseBumper(bump);
        StartCoroutine(ResponseBumperR(bump));
    }

    private void ResponseBumper(GameObject bump) {
        bump.GetComponent<Animator>().SetBool("ResponseBump", true);
        
        var lamp = bump.transform.parent.GetComponentInChildren<Light>();
        lightScript.StrobeLamp(lamp, powerLamp, flashPower);
    }
    private IEnumerator ResponseBumperR(GameObject bump) {
        yield return new WaitForSeconds(0.1f);
        bump.GetComponent<Animator>().SetBool("ResponseBump", false);
    }
}
