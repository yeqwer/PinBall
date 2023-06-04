using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloserScript : MonoBehaviour
{
    [HideInInspector] public bool close = false;
    void Update()
    {
        if (close) {
            this.GetComponent<Collider>().isTrigger = false;
        } else {
            this.GetComponent<Collider>().isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Ball")) {
            close = true;
        }
    }
}
