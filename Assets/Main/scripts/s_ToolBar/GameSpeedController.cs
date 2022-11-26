using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSpeedController : MonoBehaviour
{


    public int minSpeed = 0;
    public int maxSpeed = 4;
    public int speedValue = 1;
    public TextMeshProUGUI mySpeedText;
    public string label = "speed: ";


    private void Start()
    {
        mySpeedText.text = label + Time.timeScale.ToString();
    }
    [Button]
    public void OnAddSpeedButtonPressed()
    {
        speedValue++;
        IncrementGameSpeed();

    }
    [Button]
    public void OnSubSpeedButtonPressed()
    {
        speedValue--;
        IncrementGameSpeed();
    }

    private void IncrementGameSpeed()
    {

        speedValue = Mathf.Clamp(speedValue, minSpeed, maxSpeed);

        Time.timeScale = speedValue;
        DisplayUI();
    }

    private void DisplayUI()
    {
        mySpeedText.text = label + speedValue.ToString();
    }
}
