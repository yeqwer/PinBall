using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshPro textScore;
    public TextMeshPro textMultiplier;
    public TextMeshPro textButtonBonus;
    public TextMeshPro textMission;
    public TextMeshPro textBall;
    public TextMeshPro gameOver;

    public int scoreCount = 0;
    public int multiplierCount = 1;
    public int buttonBonusCount = 0;
    public int ballCount = 3;
    public bool gameEnd = false;
    public bool missionComplete = false;

    void Start() {
        gameOver.gameObject.SetActive(false);
    }

    void Update() {
        textScore.text = scoreCount.ToString();
        textMultiplier.text = "x" + multiplierCount.ToString();
        textButtonBonus.text = "+ " + buttonBonusCount.ToString();
        textBall.text = ballCount.ToString();

        if (multiplierCount == 12) {
            textMultiplier.color = Color.red;
        } else {
            textMultiplier.color = Color.white;
        }

        if (missionComplete) {
            textMission.color = Color.green;
            StartCoroutine(SetMissionCompelete());
        } else {
            textMission.color = new Color(0, 255, 236, 255);
        }
        
        GameOverCheck();
    }

    private IEnumerator SetMissionCompelete() {
        yield return new WaitForSeconds(10f);
        missionComplete = false;
    }

    private void GameOverCheck() {
        if (gameEnd) {
            gameOver.gameObject.SetActive(true);
        }
    }
}
