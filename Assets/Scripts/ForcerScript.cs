using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcerScript : MonoBehaviour
{ 
    public float powerForce = 5f;
    public ForceHelperScript forceHelper;
    public List<AudioClip> responseAudioEffect;

    void Awake() {
        forceHelper = this.GetComponentInParent<ForceHelperScript>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            if (forceHelper.canForce) {
            other.gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.forward * powerForce);
            forceHelper.canForce = false;

            var source = this.GetComponent<AudioSource>();
            source.clip = responseAudioEffect[Random.Range(0, responseAudioEffect.Count)]; 
            source.Play();
            }
        }
    }
}
