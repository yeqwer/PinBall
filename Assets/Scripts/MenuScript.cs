using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void SetMenu() {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void SetGame() {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
