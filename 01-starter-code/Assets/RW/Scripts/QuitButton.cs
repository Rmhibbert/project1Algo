using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;  // Stop playing the game in Unity Editor
        #else
        Application.Quit();  // Quit the application when built
        #endif
    }
}

