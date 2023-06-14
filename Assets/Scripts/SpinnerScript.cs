using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerScript : MonoBehaviour
{
    public List<GameObject> spinners;
    public LightScript lightScript;
    public ScoreCounterScript scoreCounterScript;

    void Awake() {
        spinners = new List<GameObject>();
        lightScript = FindObjectOfType<LightScript>();
        scoreCounterScript = FindObjectOfType<ScoreCounterScript>();
    }

    void Start() {
        spinners.AddRange(GameObject.FindGameObjectsWithTag("Spinner"));
    }

    public void CheckSpinner(GameObject spin) {
        int index = spinners.IndexOf(spin);

        scoreCounterScript.SpinnerCount();
        //Mission
        ResponseSpinner(spin);
        StartCoroutine(ResponseSpinnerReverse(spin));
    }

    private void ResponseSpinner(GameObject spin) {
        spin.GetComponent<Animator>().SetBool("ResponseSpin", true);
        
        //lightScript.ShutDownLamp(spin.transform.parent.GetComponentInChildren<Light>());
    }
    private IEnumerator ResponseSpinnerReverse(GameObject spin) {
        yield return new WaitForSeconds(0.2f);
        spin.GetComponent<Animator>().SetBool("ResponseSpin", false);
    }
}
