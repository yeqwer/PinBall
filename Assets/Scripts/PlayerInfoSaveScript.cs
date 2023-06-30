using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfoSaveScript : MonoBehaviour
{
    public TextMeshProUGUI textHiScore;
    void Start() {
        var score = GetPlayerScore();
        textHiScore.text = score.ToString();
    }
    public void SetPlayerScore(int score) {
        if (GetPlayerScore() < score) {
            PlayerPrefs.SetInt("HiScore", score);
            textHiScore.text = score.ToString();
        }
    }

    public int GetPlayerScore() {
        int score = PlayerPrefs.GetInt("HiScore");
        return score;
    }
}
