using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObjectScript : MonoBehaviour
{
    public float explosionStrength = 100f;   
    void OnCollisionEnter (Collision other) {
        other.rigidbody.AddExplosionForce(explosionStrength, this.transform.position, 5);
    }
}
