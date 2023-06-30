using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject teletortTo;
    public GameObject ball;
    public float timer = 0.5f;
    public float powerForceAfterTeleport = 10f;
    public List<AudioClip> responseAudioEffect;
    private bool timerEnd = false;
    private bool teleport = false;

    void Update() {
       if (teleport) {
            if(!timerEnd) {
                Timer();
            } else if (timerEnd) {
                SpawnAndForce();
                teleport = false;
                timerEnd = false;
            }
       }
    }
    private void Timer() {
        var localTimer = timer;
        if (timer > 0) {
            timer -= Time.deltaTime;
        } else {
            timer = 0.5f;
            timerEnd = true;
        }     
    }
    private void SpawnAndForce() {
        var source = this.GetComponent<AudioSource>();
        source.clip = responseAudioEffect[1]; 
        source.Play();

        var spawnedBall = Instantiate(ball, teletortTo.transform.position, teletortTo.transform.rotation);
        spawnedBall.GetComponent<Rigidbody>().AddForce(teletortTo.transform.forward * Random.Range((powerForceAfterTeleport - 15), (powerForceAfterTeleport + 15)));
    }

    private void OnTriggerEnter(Collider other) {
        var source = this.GetComponent<AudioSource>();

        if(other.gameObject.CompareTag("Ball")) {
            Destroy(other.gameObject);
            teleport = true;

            source.clip = responseAudioEffect[0]; 
            source.Play();
        }
    }
}