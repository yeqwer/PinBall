using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVelocityScript : MonoBehaviour
{
    public float power = 10f;
    void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.GetComponent<Rigidbody>().AddForce(-Vector3.forward * power);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * power);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.GetComponent<Rigidbody>().AddForce(-Vector3.left * power);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.left * power);
        }
        if (this.GetComponent<Rigidbody>().velocity == Vector3.zero) {
            this.GetComponent<Rigidbody>().velocity += new Vector3(Random.Range(0.001f, 0.002f), Random.Range(0.001f, 0.002f), Random.Range(0.001f, 0.002f)); 
        }
    }
}