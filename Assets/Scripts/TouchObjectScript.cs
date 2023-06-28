using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObjectScript : MonoBehaviour
{
    public ToggleScript toggleScript;
    public BumperScript bumperScript;
    public ButtonScript buttonScript;
    public SpinnerScript spinnerScript;
    public DumperScript dumperScript;
    public MultiplierScript multiplierScript;
    
    public float explosionStrength = 100f;   

    void Update() {

    }
    void Awake() {
        toggleScript = FindObjectOfType<ToggleScript>();
        bumperScript = FindObjectOfType<BumperScript>();
        buttonScript = FindObjectOfType<ButtonScript>();
        spinnerScript = FindObjectOfType<SpinnerScript>();
        dumperScript = FindObjectOfType<DumperScript>();
        multiplierScript = FindObjectOfType<MultiplierScript>();
    }
    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Ball")) {
            if (this.gameObject.CompareTag("Spinner")) {
                spinnerScript.CheckSpinner(this.gameObject);
            }       
            if (this.gameObject.CompareTag("Multiplier")) {
                multiplierScript.CheckMultiplier(this.gameObject);
            }
        } 
    }
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Ball")) {
            if (this.gameObject.CompareTag("Toggle")) {
                toggleScript.CheckToggle(this.gameObject);  
                other.rigidbody.AddExplosionForce(explosionStrength, this.transform.position, 5);
            }            
            if (this.gameObject.CompareTag("Bumper")) {
                bumperScript.CheckBumper(this.gameObject);
                other.rigidbody.AddExplosionForce(explosionStrength, this.transform.position, 5);
            }
            if (this.gameObject.CompareTag("Button")) {
                buttonScript.CheckButton(this.gameObject);
                other.rigidbody.AddExplosionForce(explosionStrength, this.transform.position, 5);
            }
            if (this.gameObject.CompareTag("Dumper")) {
                dumperScript.CheckDumper(this.gameObject);
                Vector3 direction = this.transform.right;
                float speed = other.rigidbody.velocity.magnitude;
                //other.rigidbody.AddForce(explosionStrength * this.transform.right, ForceMode.Impulse);
                other.rigidbody.AddForce(direction.normalized * explosionStrength * speed, ForceMode.VelocityChange);
            }
        }
    }
}
