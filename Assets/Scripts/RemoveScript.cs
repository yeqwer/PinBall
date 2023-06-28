using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveScript : MonoBehaviour
{
    
    public SpawnScript spawner;
    public PunchScript punchScript;
    public CloserScript closer;
    public ScoreScript scoreScript;

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
            
            if (punchScript.tilt) {
                punchScript.tilt = false;
                scoreScript.gameEnd = true; 
            } else if (scoreScript.ballCount != 0) {
                spawner.Spawner();
            } else {
                scoreScript.gameEnd = true;
            }
        }
    }
}