using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceHelperScript : MonoBehaviour
{
    public bool canForce;
    private float timer = 0.5f;
    private bool startTimer = false;
    void Update() {
        if (startTimer) {
            Timer();
        }
    }

    private void Timer() {
        var localTimer = timer;
        if (timer > 0) {
            timer -= Time.deltaTime;
        } else {
            timer = 0.5f;
            canForce = false;
            startTimer = false;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            canForce = true;
            startTimer = true;
        }
    }
}