using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveScript : MonoBehaviour
{
    public SpawnScript spawner;

    void Awake() {
        spawner = FindObjectOfType<SpawnScript>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ball")) {
        Destroy(other.gameObject);
        spawner.Spawner();
        }
    }
}