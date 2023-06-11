using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierScript : MonoBehaviour
{
    public List<GameObject> multipliers;
    public List<GameObject> activeObjects = new List<GameObject>();
    public LightScript lightScript;
    public ScoreCounterScript scoreCounterScript;
    public float flashPower = 8f;

    void Awake() {
        multipliers = new List<GameObject>();
        lightScript = FindObjectOfType<LightScript>();
        scoreCounterScript = FindObjectOfType<ScoreCounterScript>();
    }

    void Start() {
        multipliers.AddRange(GameObject.FindGameObjectsWithTag("Multiplier"));
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            var active = ActivateAllMultipliers();  
            Debug.Log(active.Count); 
        }
    }

    public void CheckMultiplier(GameObject mult) {
        int index = multipliers.IndexOf(mult);
        //Mission
        ResponseMultiplier(mult, index);
    }

    public List<GameObject> ActivateAllMultipliers() {

        // activeObjects = new List<GameObject>();
        // foreach (var mult in multipliers){
        //     var active = mult.transform.parent.GetComponentInChildren<Light>().intensity;

        //     if (active != 0) {
        //         activeObjects.Add(mult);
        //     }        
        // }
        foreach (var mult in multipliers) { //Shut down all
            var lamp = mult.transform.parent.GetComponentInChildren<Light>();
            int index = multipliers.IndexOf(mult);

            lightScript.ShutDownLamp(lamp);
            scoreCounterScript.MultiplierCountRemove(index);
        }

        foreach (var mult in multipliers) { //Active all
            var lamp = mult.transform.parent.GetComponentInChildren<Light>();
            int index = multipliers.IndexOf(mult);
            var collider = mult.GetComponent<Collider>().enabled = false; //Enable colliser

            lightScript.EnablingLamp(lamp, flashPower);
            scoreCounterScript.MultiplierCountAdd(index);
        }

        return activeObjects;
    }

    public IEnumerator ShutDownAll(float time) { //GameObject oldActiveMultipliers

        yield return new WaitForSeconds(time);
        foreach (var mult in multipliers) {
            var lamp = mult.transform.parent.GetComponentInChildren<Light>();
            int index = multipliers.IndexOf(mult);
            var collider = mult.GetComponent<Collider>().enabled = true; //Disable colliser

            lightScript.ShutDownLamp(lamp);
            scoreCounterScript.MultiplierCountRemove(index);
        }
    }
    

    private void ResponseMultiplier(GameObject mult, int index) {
        var lamp = mult.transform.parent.GetComponentInChildren<Light>();
        if (lamp.intensity == 0) {
            lightScript.EnablingLamp(lamp, flashPower);
            scoreCounterScript.MultiplierCountAdd(index);
        } else if (lamp.intensity != 0) {
            lightScript.ShutDownLamp(lamp);
            scoreCounterScript.MultiplierCountRemove(index);
        }
       
    }
}
