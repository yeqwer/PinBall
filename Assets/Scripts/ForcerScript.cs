using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcerScript : MonoBehaviour
{ 
    public float powerForce = 5f;
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Force");
        if(other.gameObject.CompareTag("Ball")) {
            other.gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward * powerForce);
        Debug.Log("Force1");
        }
    }
}
