using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameModeController : MonoBehaviour
{
    public enum gameMode { play, debug }
    public gameMode gameState;


    public GameObject toolBarObj;
    public PinchAndZoom pinchAndZoom;
    bool currentModePlay = true;


    public TextMeshProUGUI displayGameState;
    public string lable = "Mode: ";

    private void Start()
    {
        pinchAndZoom.enabled = false;
        toolBarObj.SetActive(false);
        displayGameState.text = lable + gameState.ToString();


    }

    //private void Update()
    //{
    //    if (gameState == gameMode.play)
    //    {


    //    }
    //    if (gameState == gameMode.debug)
    //    {


    //    }
    //}


    public void OnDebugButtonPressed()
    {
        currentModePlay = !currentModePlay;

        if (currentModePlay)
        {
            gameState = gameMode.play;

            toolBarObj.SetActive(false);
            pinchAndZoom.enabled = false;
        }
        if (!currentModePlay)
        {
            gameState = gameMode.debug;

            toolBarObj.SetActive(true);
            pinchAndZoom.enabled = true;
        }

        displayGameState.text = lable + gameState.ToString();
    }
}
