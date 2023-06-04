using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVelocityScript : MonoBehaviour
{
    public float power = 10f;
    void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            Debug.Log("Up");
            transform.GetComponent<Rigidbody>().AddForce(-Vector3.forward * power);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            Debug.Log("Down");
            transform.GetComponent<Rigidbody>().AddForce(Vector3.forward * power);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            Debug.Log("Left");
            transform.GetComponent<Rigidbody>().AddForce(-Vector3.left * power);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            Debug.Log("Right");
            transform.GetComponent<Rigidbody>().AddForce(Vector3.left * power);
        }
    }
}
