using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject teletortTo;
    public GameObject ball;
    public float timer = 1f;
    public float powerForceAfterTeleport = 10f;
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
            timer = 1f;
            timerEnd = true;
        }     
    }
    private void SpawnAndForce() {
        var spawnedBall = Instantiate(ball, teletortTo.transform.position, teletortTo.transform.rotation);
        spawnedBall.GetComponent<Rigidbody>().AddForce(teletortTo.transform.forward * Random.Range((powerForceAfterTeleport - 15), (powerForceAfterTeleport + 15)));
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ball")) {
            Destroy(other.gameObject);
            teleport = true;
        }
    }
}