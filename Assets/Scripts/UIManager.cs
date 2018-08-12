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

    public TextMeshProUGUI blockText;
    
    // Use this for initialization
    void Start()
    {
        uiCanvas.enabled = true;
        gameOverCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        blockText.text = "Current Boxes: " + gameManager.CurrentBlocks + " / " + gameManager.maxBlocks;
    }

    public void ToggleGameOver()
    {
        uiCanvas.enabled = false;
        gameOverCanvas.enabled = true;
    }
}
