using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounterScript : MonoBehaviour
{
    public ScoreScript scoreScript;
    public int totalScore;
    public int bumperScore;
    public int multiplierScore;
    public int buttonAdder;
    public int dumperCount; 
    public int spinnerCount;
    public List<int> listMultiplier;

    void Awake() {
        scoreScript = FindObjectOfType<ScoreScript>();
    }
    void Update() {
        multiplierScore = 1 + listMultiplier.Count;
        scoreScript.multiplierCount = multiplierScore;
        scoreScript.buttonBonusCount = buttonAdder;
    }
    private void CountPerHit() {
        //scoreScript.scoreCount += bumperScore * multiplierScore;
        totalScore = (bumperScore + dumperCount + buttonAdder + spinnerCount) * multiplierScore;
        bumperScore = 0;
        dumperCount = 0;
        scoreScript.scoreCount += totalScore;
    }
    public void BumperCount(int index) {
        if (index == 0) {
            bumperScore += 200;
        } else if (index <= 3) {
            bumperScore += 100;
        } else if (index <= 5) {
            bumperScore += 150;
        } else if (index == 6) {
            bumperScore += 250;
        } else if (index == 7) {
            bumperScore += 200;
        }
        CountPerHit();
    }
    public void DumperCount() {
        dumperCount = 666;
        CountPerHit();
    }
    public void SpinnerCount() {
        spinnerCount = 1234;
        CountPerHit();
    }
    public void ButtonCount(int index) {
        buttonAdder += 275;
    }
    public void MultiplierCountAdd(int index) {
        listMultiplier.Add(index);
    }
    public void MultiplierCountRemove(int index) {
        listMultiplier.Remove(index);
    }
}
