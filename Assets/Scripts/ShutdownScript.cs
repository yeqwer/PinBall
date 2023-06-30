using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShutdownScript : MonoBehaviour
{
    private InputController inputController;
    private PunchScript punchScript;
    private List<TouchObjectScript> touchObjectScript;
    private Color startColor;
    public List<TextMeshPro> tmProGameName;
    public List<Light> allLamp;
    public Material emissionMaterial;
    public TextMeshPro gameStatus;
    public TextMeshPro ballCounter;
    private AudioBackgroundScript audioBackgroundScript;
    public AudioSource shutDownSource;
    public List<AudioClip> responseAudioEffect;
    private bool keySound = true;

    void Awake() {
        punchScript = FindObjectOfType<PunchScript>();
        inputController = FindObjectOfType<InputController>();
        audioBackgroundScript = FindObjectOfType<AudioBackgroundScript>();
        touchObjectScript = new List<TouchObjectScript>(); 
        allLamp = new List<Light>();
    }

    void Start() {
        allLamp.AddRange(FindObjectsOfType<Light>());
        allLamp.RemoveAll(i => i.gameObject.CompareTag("MainLight"));

        touchObjectScript.AddRange(FindObjectsOfType<TouchObjectScript>());

        emissionMaterial.EnableKeyword("_EMISSION");

        foreach (var text in tmProGameName) {
            startColor = text.color;
        }
    }

    void Update() {
        if (punchScript.tilt) {
            emissionMaterial.DisableKeyword("_EMISSION");
            gameStatus.gameObject.SetActive(true);
            gameStatus.text = "TILT!";
            ballCounter.text = "X";
            inputController.activeInput = false;
            audioBackgroundScript.volume = 0.05f;

            if (keySound){
                shutDownSource.clip = responseAudioEffect[0]; 
                shutDownSource.Play();
                keySound = false;
            }
            
            foreach (var touch in touchObjectScript) {
                Destroy(touch);
            }
            foreach (var lamp in allLamp) {
                lamp.intensity = 0;
            }
            foreach (var text in tmProGameName) {
                text.color = new Color32(0, 41, 38, 255); //00443F;
            }
        } else {
            gameStatus.text = "GAME OVER!";
        }
    }
}
