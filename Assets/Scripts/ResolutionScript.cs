using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionScript : MonoBehaviour
{
    void Start() {
        var screenResolution = Screen.currentResolution;
        screenResolution.height -= 200;
        Screen.SetResolution(screenResolution.height/2, screenResolution.height, FullScreenMode.Windowed);       
    }
}
