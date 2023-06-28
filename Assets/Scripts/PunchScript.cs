using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript : MonoBehaviour
{
    public Vector3 targetRotation = new Vector3(0, 0, 0.5f);
    private Vector3 startGravity;
    private float targetGravity;
    private Vector3 startRotation;
    public float targetTime = 0.5f;
    private float timer = 0;
    public bool tilt = false;

    void Start() {
        startRotation = this.transform.eulerAngles;
        startGravity = Physics.gravity;
        targetGravity = targetRotation.z * 2;
    }
    void Update() {
        CheckTilt();
        ChangeRotation();
    }

    void CheckTilt() {
        if (!tilt) {
            if (Input.GetKey(KeyCode.E)) {
                if (timer < targetTime) {
                    timer += Time.deltaTime;
                } else {
                    tilt = true;
                }
            }
            else if (Input.GetKey(KeyCode.Q)) {
                if (timer < targetTime) {
                    timer += Time.deltaTime;
                } else {
                    tilt = true;
                }
            }
            else {
                timer = 0f;
            }
        }
    }

    void ChangeRotation() {
        if (Input.GetKey(KeyCode.E)) {   
            this.transform.eulerAngles = startRotation + targetRotation;
            Physics.gravity = new Vector3(-targetGravity, startGravity.y, startGravity.z);

        } else if (Input.GetKey(KeyCode.Q)) {
            this.transform.eulerAngles = startRotation - targetRotation;
            Physics.gravity = new Vector3(targetGravity, startGravity.y, startGravity.z);                
        } else {
            this.transform.eulerAngles = startRotation;
            Physics.gravity = startGravity;
        }
    }       
}
