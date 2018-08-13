using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    AudioManager audioManager;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        audioManager.playOnce = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
