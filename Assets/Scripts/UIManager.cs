using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;

    public Canvas uiCanvas;
    public Canvas gameOverCanvas;

    public TextMeshProUGUI currentBlocksText;
    public TextMeshProUGUI deliveredBlocksText;
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highScore;
    
    // Use this for initialization
    void Start()
    {
        uiCanvas.enabled = true;
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentBlocksText.text = "Current Boxes: " + gameManager.CurrentBlocks + " / " + gameManager.maxBlocks;
        deliveredBlocksText.text = "Delivered Boxes: " + gameManager.DeliveredBlocks;
    }

    public void ToggleGameOver()
    {
        uiCanvas.enabled = false;
        gameOverCanvas.enabled = true;
        
        currentScore.text = "Score: " + gameManager.DeliveredBlocks;
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
}
