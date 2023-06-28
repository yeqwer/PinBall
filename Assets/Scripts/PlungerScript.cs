using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlungerScript : MonoBehaviour
{
    private PunchScript punchScript;
    private InputController inputController;
    private NewAction inputSystem;
    public float power;
    public float min;
    public float maxPower = 100f;
    public Slider powerSlider;
    public List<Rigidbody> ballList;
    public bool ballReady;

    void Start() {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        ballList = new List<Rigidbody>();

        inputController = FindObjectOfType<InputController>();
        punchScript = FindObjectOfType<PunchScript>();
        inputSystem = new NewAction();
        inputSystem.Enable();
    }

    void Update() {
        CheckInput();
        PullBall();  
        PullAfterTilt();
    }

    void PullBall() {
        if (ballReady) {
            powerSlider.gameObject.SetActive(true);
        } else {
            powerSlider.gameObject.SetActive(false);
        }

        powerSlider.value = power;

        if(ballList.Count > 0) {
            ballReady = true;

            if(inputSystem.Player.Plunger.inProgress) {
                if(power < maxPower) {
                    power += 50 * Time.deltaTime;
                }
            }
            else if(!inputSystem.Player.Plunger.inProgress) {
                foreach (Rigidbody r in ballList) {
                    r.AddForce(power * 0.3f * -Vector3.forward);
                }
            }
        } else {
            ballReady = false;
            power = 0f;
        }
    }

    
    void PullAfterTilt() {
        if (punchScript.tilt) {
            if(ballList.Count > 0) {
                foreach (Rigidbody r in ballList) {
                    r.AddForce(20 * -Vector3.forward);
                }
            }
        }        
    }

    private void OnTriggerEnter(Collider other) {
         if(other.gameObject.CompareTag("Ball")) {
            ballList.Add(other.gameObject.GetComponent<Rigidbody>());
         }
    }

        private void OnTriggerExit(Collider other) {
         if(other.gameObject.CompareTag("Ball")) {
            ballList.Remove(other.gameObject.GetComponent<Rigidbody>());
            power = 0f;
         }
    }
    void CheckInput() {
        if (inputController.activeInput) {
            inputSystem.Enable();
        } else {
            inputSystem.Disable();
        }
    }
}
