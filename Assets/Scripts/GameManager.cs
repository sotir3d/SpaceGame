using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;

    public int maxBlocks;

    int currentBlocks = 0;

    private void Start()
    {
        Time.timeScale = 1f;
        CurrentBlocks = 0;
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

    void GameOver()
    {
        uiManager.ToggleGameOver();
        Time.timeScale = 0;
    }

    public void RestartScene()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
