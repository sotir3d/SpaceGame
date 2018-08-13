using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public AudioManager audioManager;

    public int maxBlocks;

    bool playOnce = false;
    int currentBlocks = 0;
    int deliveredBlocks = 0;

    private void Start()
    {
        Time.timeScale = 1f;
        CurrentBlocks = 0;
        audioManager = FindObjectOfType<AudioManager>();
    }

    public int CurrentBlocks
    {
        get
        {
            return currentBlocks;
        }

        set
        {
            currentBlocks = value;
        }
    }

    public int DeliveredBlocks
    {
        get
        {
            return deliveredBlocks;
        }

        set
        {
            deliveredBlocks = value;
        }
    }

    private void Update()
    {

        if (CurrentBlocks >= maxBlocks)
            GameOver();
    }

    public void AddBlock()
    {
        CurrentBlocks++;
    }

    public void RemoveBlock()
    {
        CurrentBlocks--;
    }

    public void RestartScene()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void GameOver()
    {
        if (!PlayerPrefs.HasKey("HighScore"))
            PlayerPrefs.SetInt("HighScore", DeliveredBlocks);

        else if (DeliveredBlocks > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", DeliveredBlocks);

        if(!playOnce)
        {
            audioManager.Play("GameOver");
            playOnce = true;
        }

        if(uiManager != null)
            uiManager.ToggleGameOver();
        Time.timeScale = 0;
    }
}
