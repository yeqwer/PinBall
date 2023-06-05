using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcerScript : MonoBehaviour
{ 
    public float powerForce = 5f;
    public ForceHelperScript forceHelper;

    void Awake() {
        forceHelper = this.GetComponentInParent<ForceHelperScript>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            if (forceHelper.canForce) {
            other.gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward * powerForce);
            forceHelper.canForce = false;
            Debug.Log("Force");
            }
        }
    }
}
