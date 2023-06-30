using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveScript : MonoBehaviour
{
    
    public SpawnScript spawner;
    public PunchScript punchScript;
    public CloserScript closer;
    public ScoreScript scoreScript;
    public List<AudioClip> responseAudioEffect;
    public AudioSource fallSource;
    public AudioSource infoSource;
    void Awake() {
        spawner = FindObjectOfType<SpawnScript>();
        closer = FindObjectOfType<CloserScript>();
        scoreScript = FindObjectOfType<ScoreScript>();
        punchScript = FindObjectOfType<PunchScript>();
        
    }    
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ball")) {
            Destroy(other.gameObject);
            closer.close = false; //Set Closer
            
            scoreScript.ballCount -= 1;

            fallSource.clip = responseAudioEffect[0];
            
            if (punchScript.tilt) {
                punchScript.tilt = false;
                scoreScript.gameEnd = true;

                infoSource.clip = responseAudioEffect[1];
                infoSource.Play(); 

            } else if (scoreScript.ballCount != 0) {
                infoSource.clip = responseAudioEffect[2];
                infoSource.Play();

                spawner.Spawner();
            } else {
                infoSource.clip = responseAudioEffect[1];
                infoSource.Play();

                scoreScript.gameEnd = true;
            }
        }
    }
}