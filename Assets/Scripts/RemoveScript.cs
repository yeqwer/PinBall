using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveScript : MonoBehaviour
{
    public SpawnScript spawner;
    public CloserScript closer;

    void Awake() {
        spawner = FindObjectOfType<SpawnScript>();
        closer = FindObjectOfType<CloserScript>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ball")) {
        Destroy(other.gameObject);
        spawner.Spawner();
        closer.close = false; //Set Closer
        }
    }
}