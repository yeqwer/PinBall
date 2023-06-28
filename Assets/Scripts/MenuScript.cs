using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void SetMenu() {
        SceneManager.LoadScene("Menu");
    }
    public void SetRetry() {
        SceneManager.LoadScene("Game");
    }
}
