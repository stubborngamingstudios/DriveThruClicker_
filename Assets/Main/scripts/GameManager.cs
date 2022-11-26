using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int maxFps = 300;
    private float count;
    public TextMeshProUGUI fpsCounterText;


    private void Start()
    {
        CapFrames(maxFps);

        StartCoroutine(fpscounter());
    }



    private void CapFrames(int targetRate)
    {
        Application.targetFrameRate = targetRate;
    }

    public void ProcessExitGame()
    {
        Application.Quit();
    }


    private IEnumerator fpscounter()
    {
        GUI.depth = 2;
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.1f);

            fpsCounterText.text = "FPS: " + Mathf.Round(count).ToString();
        }
    }

}

