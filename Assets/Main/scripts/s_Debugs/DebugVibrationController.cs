using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DebugVibrationController : MonoBehaviour
{


    public Slider vibration_Slider;
    public TextMeshProUGUI vibration_txt;

    public float vibValue = 50;
    public int vibMin = 50;
    public int vibMax = 500;

    private void OnEnable()
    {
        ScaleUpDo.onCashGaied += ProcessVibration;
    }

    private void OnDisable()
    {
        ScaleUpDo.onCashGaied -= ProcessVibration;
    }


    private void Start()
    {
        Vibration.Init();



        vibration_Slider.minValue = vibMin;
        vibration_Slider.maxValue = vibMax;

        vibration_Slider.value = vibMin;

        vibration_txt.text = vibValue.ToString();

    }
    private void ProcessVibration()
    {
        Vibration.Vibrate((int)vibValue);
    }

    public void OnVibrationChanged()
    {

        vibValue = vibration_Slider.value;

        vibration_txt.text = vibValue.ToString();
    }
}
