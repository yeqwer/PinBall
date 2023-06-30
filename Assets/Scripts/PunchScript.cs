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
    public List<AudioClip> responseAudioEffect;
    private InputController inputController;
    private NewAction inputSystem;
    private bool keySound = true;

    void Start() {
        startRotation = this.transform.eulerAngles;
        startGravity = Physics.gravity;
        targetGravity = targetRotation.z * 2;

        inputController = FindObjectOfType<InputController>();
        inputSystem = new NewAction();
    }
    void Update() {
        CheckTilt();
        ChangeRotation();
        ChangeAudio();
        //CheckInput();
        inputSystem.Enable();
    }

    void CheckTilt() {
        if (!tilt) {
            if (inputSystem.Player.PunchR.inProgress) {
                if (timer < targetTime) {
                    timer += Time.deltaTime;
                } else {
                    tilt = true;
                }
            }
            else if (inputSystem.Player.PunchL.inProgress) {
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
        
        if (inputSystem.Player.PunchR.inProgress) {   
            this.transform.eulerAngles = startRotation + targetRotation;
            Physics.gravity = new Vector3(-targetGravity, startGravity.y, startGravity.z);

        } else if (inputSystem.Player.PunchL.inProgress) {
            this.transform.eulerAngles = startRotation - targetRotation;
            Physics.gravity = new Vector3(targetGravity, startGravity.y, startGravity.z);  

        } else {
            this.transform.eulerAngles = startRotation;
            Physics.gravity = startGravity;
        }
    }
    void ChangeAudio() {
        var source = this.GetComponent<AudioSource>();
        if (inputSystem.Player.PunchR.inProgress | inputSystem.Player.PunchL.inProgress) {  
            if (keySound) {
                source.clip = responseAudioEffect[0];
                source.Play();

                keySound = false;
            }  
        } else if (!keySound){
            source.clip = responseAudioEffect[1]; 
            source.Play();

            keySound = true;
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
