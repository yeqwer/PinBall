using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionScript : MonoBehaviour
{
    public ToggleScript toggleScript;
    public LightScript lightScript;
    public ScoreScript scoreScript;
    public MultiplierScript multiplierScript;
    public List<GameObject> activeObjects;

    void Awake() {
        toggleScript = FindObjectOfType<ToggleScript>();
        lightScript = FindObjectOfType<LightScript>();
        scoreScript = FindObjectOfType<ScoreScript>();
        multiplierScript = FindObjectOfType<MultiplierScript>();

    }

    void Update() {

        activeObjects = new List<GameObject>();
        CheckActiveToggles(); 
        if (activeObjects.Count == 0){

            ReSpawnToggles();
            //Mission complete
            scoreScript.missionComplete = true;

            var oldActiveMultipliers = multiplierScript.ActivateAllMultipliers();
            StartCoroutine(multiplierScript.ShutDownAll(10f));
        }  
         
    }

    private void CheckActiveToggles() {
        foreach (var toggle in toggleScript.toggles){
            var active = toggle.GetComponent<Animator>().GetBool("Active");

            if (active) {
                activeObjects.Add(toggle);
            }        
        }
    }

    private void ReSpawnToggles() {

        foreach (var toggle in toggleScript.toggles){
            toggle.GetComponent<Animator>().SetBool("Active", false);
            lightScript.ShutDownLamp(toggle.transform.parent.GetComponentInChildren<Light>());
        }

        List<GameObject> list = SelectRandomObjects(Random.Range(5,10));

        foreach (var toggle in list) {
            toggle.GetComponent<Animator>().SetBool("Active", true);
            lightScript.EnablingLamp(toggle.transform.parent.GetComponentInChildren<Light>(), 8f);
        }
    }

    private List<GameObject> SelectRandomObjects(int count) {

        List<GameObject> randomObjects = new List<GameObject>();

        for (int i = 0; i < count; i++) {
            int randomIndex = Random.Range(0, toggleScript.toggles.Count);
            randomObjects.Add(toggleScript.toggles[randomIndex]);
        }
        return randomObjects;
    }
}
