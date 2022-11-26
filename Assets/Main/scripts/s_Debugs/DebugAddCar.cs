using KamaliDebug;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAddCar : MonoBehaviour
{


    public DebugLaneController debugLaneController;
    public UIController uiController;


    public int addCarIndex;

    public bool activeDefaultOnStart = false;





    private void Start()
    {
        if (activeDefaultOnStart) ProcessAddNewCar();
    }



    [Button]
    public void ResetAddIndex()
    {
        addCarIndex = -1;



    }

    public void DisableAllCars()
    {
        for (int i = 0; i < debugLaneController.myCars.Count; i++)
        {
            EnableOrDisableCars(i, false);
            debugLaneController.activeCarCount = -1;

        }
    }


    [Button]
    public void ProcessAddNewCar()
    {

        if (addCarIndex != 2) addCarIndex++;




        if (addCarIndex == 0)
        {
            EnableOrDisableCars(addCarIndex, true);
        }
        if (addCarIndex == 1)
        {
            EnableOrDisableCars(addCarIndex, true);
        }
        if (addCarIndex == 2)
        {
            EnableOrDisableCars(addCarIndex, true);
            DebugX.Log("You added max cars!:orange:b;");
        }







    }

    private void EnableOrDisableCars(int targetIndex, bool activeState)
    {
        debugLaneController.myCars[targetIndex].SetActive(activeState);
        debugLaneController.activeCarCount++;
    }


}
