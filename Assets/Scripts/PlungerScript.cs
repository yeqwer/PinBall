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
    public GameObject buttonPlunger;
    public List<Rigidbody> ballList;
    private bool ballReady;
    private bool keySound = true;
    public List<AudioClip> responseAudioEffect;

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
        var source = this.GetComponent<AudioSource>();

        if (ballReady) {
            powerSlider.gameObject.SetActive(true);
            buttonPlunger.SetActive(true);
        } else {
            powerSlider.gameObject.SetActive(false);
            buttonPlunger.SetActive(false);
        }

        powerSlider.value = power;

        if(ballList.Count > 0) {
            ballReady = true;

            if(inputSystem.Player.Plunger.inProgress) {

                if (keySound) {
                    source.clip = responseAudioEffect[0]; 
                    source.loop = true;
                    source.Play();

                    keySound = false;
                }

                if(power < maxPower) {
                    power += 50 * Time.deltaTime;
                    source.pitch += Time.deltaTime;
                } else {
                    StartBall(source);
                }
                
            }
            else if(!inputSystem.Player.Plunger.inProgress) {
                StartBall(source);
            }
        } else {
            ballReady = false;
            power = 0f;
        }
    }

    void StartBall(AudioSource source) {
        foreach (Rigidbody r in ballList) {
                    r.AddForce(power * 0.3f * -Vector3.forward);
                }
                if (!keySound) {
                    source.clip = responseAudioEffect[1]; 
                    source.loop = false;
                    source.pitch = 1;
                    source.Play();

                    keySound = true;
                }
    }
    
    void PullAfterTilt() {
        var source = this.GetComponent<AudioSource>();
        if (punchScript.tilt) {
            if(ballList.Count > 0) {
                foreach (Rigidbody r in ballList) {
                    r.AddForce(20 * -Vector3.forward);
                }
                keySound = false;
                StartBall(source);
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
