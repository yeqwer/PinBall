using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPlungers : MonoBehaviour
{
    public float maxPower = 100f;  
    public List<Rigidbody> ballList;
    public List<AudioClip> responseAudioEffect;
    private float timer = 1.5f;

    void Start() {
        ballList = new List<Rigidbody>();
    }

    void Update() {
        if(ballList.Count > 0) {
            Timer();
        }
    }

    private void Timer() {
        var source = this.GetComponent<AudioSource>();
        var localTimer = timer;

        if (timer > 0) {
            timer -= Time.deltaTime; 
        } else {
            foreach (Rigidbody r in ballList) {
                r.AddForce(maxPower * -Vector3.forward);
            }
            timer = 1.5f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ball")) {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());

            var source = this.GetComponent<AudioSource>();
            source.clip = responseAudioEffect[0]; 
            source.Play();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Ball")) {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());

            var source = this.GetComponent<AudioSource>();
            source.clip = responseAudioEffect[1]; 
            source.Play();
        }
    }
}
