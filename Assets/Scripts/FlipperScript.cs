using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    private InputController inputController;
    private NewAction inputSystem;
    public List<AudioClip> responseAudioEffect;
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrenght = 10000f;
    public float flipperDamper = 150f;
    public string inputName;
    public HingeJoint hinge;
    private bool keySound = true;

    void Start() {
        inputController = FindObjectOfType<InputController>();

        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;

        inputSystem = new NewAction();
    }

    void Update() {
        FlipperPunch();
        CheckInput();
          
    }
    void FlipperPunch() {
        JointSpring spring = new JointSpring();

        spring.spring = hitStrenght;
        spring.damper = flipperDamper;

        var source = this.GetComponent<AudioSource>();

        if (this.transform.CompareTag("LFlipper")) {   
            if (inputSystem.Player.FlipperL.inProgress) {
                spring.targetPosition = pressedPosition;

                if (keySound) {
                    ResponseFlipper(0);
                    keySound = false;
                }
            } else {
                spring.targetPosition = restPosition;

                if (!keySound) {
                    ResponseFlipper(1);
                    keySound = true;
                }
            }
        }
       
        if (this.transform.CompareTag("RFlipper")) {
            if (inputSystem.Player.FlipperR.inProgress) {
                spring.targetPosition = pressedPosition;

                if (keySound) {
                    ResponseFlipper(0);
                    keySound = false;
                }
            } else {
                spring.targetPosition = restPosition;
                
                if (!keySound) {
                    ResponseFlipper(1);
                    keySound = true;
                }
            }

                
        }

        hinge.spring = spring;
        hinge.useLimits = true;
    }

    void ResponseFlipper(int num) {
        var source = this.GetComponent<AudioSource>();

        source.clip = responseAudioEffect[num];         
        source.Play();       
    }

    void CheckInput() {
        if (inputController.activeInput) {
            inputSystem.Enable();
        } else {
            inputSystem.Disable();
        }
    }
}
