using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DebugInputSystem : MonoBehaviour
{

    public float touchBeganCoolDown = 1F;
    private float touchBeganCoolDown_def;
    public bool screenTouched = false;

    public float touchCarSpeedMultiplier = 0.2F;



    private void Start()
    {
        touchBeganCoolDown_def = touchBeganCoolDown;
    }



    private void TimeScaleLogic()
    {
        if (Input.touchCount > 0)
        {
            Time.timeScale = 2;


        }
        else
        {
            Time.timeScale = 1;

        }
    }


    private void Update()
    {
        if (screenTouched) TouchLogic();


    }

    private void TouchLogic()
    {

        if (screenTouched)
        {

            if (touchBeganCoolDown > 0)
            {
                touchBeganCoolDown -= Time.deltaTime;

            }
            if (touchBeganCoolDown <= 0)
            {
                touchBeganCoolDown = touchBeganCoolDown_def;
                screenTouched = false;

            }

        }
    }

    public void OnInputButtonPressed()
    {

        touchBeganCoolDown = touchBeganCoolDown_def;

        screenTouched = true;



    }
}
