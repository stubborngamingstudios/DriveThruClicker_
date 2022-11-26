using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEconomyController : MonoBehaviour
{


    public float myWallet_Counter;

    [ReadOnly] public UIController uiController;


    [BoxGroup("Amounts: ")] public float perCoffeeAmount = 2;
    [BoxGroup("Amounts: ")] public float perDonutAmount = 4;
    [BoxGroup("Amounts: ")] public float perBurgerAmount = 8;


    [BoxGroup("CarBuyRates: ")] public float carBuyRate = 10;
    [BoxGroup("CarBuyRates: ")] public float carBuyRateAdder = 20;

    [BoxGroup("RoadBuyRates: ")] public float roadBuyRate = 10;
    [BoxGroup("RoadBuyRates: ")] public float roadBuyRateAdder = 20;

    [BoxGroup("MergeBuyRates: ")] public float mergeBuyRate = 50;
    [BoxGroup("MergeBuyRates: ")] public float mergeBuyRateAdder = 50;

    [BoxGroup("IncomeBuyRates: ")] public float incomeBuyRate = 500;
    [BoxGroup("IncomeBuyRates: ")] public float incomeBuyRateAdder = 100;

    [BoxGroup("ControllerScripts: ")] public DebugAddCar G_debugAddCar;
    [BoxGroup("ControllerScripts: ")] public DebugRoadController debugRoadController;
    [BoxGroup("ControllerScripts: ")] public DebugMergeCar debugMergeCar;

    [BoxGroup("StoreScripts: ")] public DebugStoreController greenStore;
    [BoxGroup("StoreScripts: ")] public DebugStoreController orangeStore;
    [BoxGroup("StoreScripts: ")] public DebugStoreController redStore;

    DebugStoreController targetStore;




    private void Start()
    {
        uiController = FindObjectOfType<UIController>();

        uiController.DisplayCarCostUI(carBuyRate);
        uiController.DisplayMergeCostUI(mergeBuyRate);
        uiController.DisplayIncomeCostUI(incomeBuyRate);
        uiController.DisplayRoadCostUI(roadBuyRate);



        uiController.DisplayWallettUI(myWallet_Counter);

    }

    //[Car buy] ButtonPressed -> check if max cars placed -> check you have cash ? else disable button

    //[Road buy]  ButtonPressed -> check if max cars placed -> check you have cash ? else disable button

    //[Car merge] TOD0:   ButtonPressed -> check if max cars placed-> check you have cash? else disable button

    //[Income] ButtonPressed -> check if max cars placed-> check you have cash? else disable button

    private void Update()
    {
        CheckMaxCarsInLane();
        CheckMaxRoad();
        CheckMaxCarsToMerge();
        CheckMaxRoadForIncome();
    }





    private void CheckMaxCarsInLane()
    {
        if (!debugMergeCar.carCount_G)
        {
            CheckWalletToActivateCarBuyButton();

        }
        else
        {
            Debug.Log("max Car Purchaces");
            uiController.EnableOrDisableTargetButton(uiController.AddCar_Button, false);
            uiController.addCarCost_Text.text = "MAX";
        }
    }
    private void CheckMaxRoad()
    {
        if (debugRoadController.activeRoadIndex < debugRoadController.myRoads.Count - 1)
        {

            CheckWalletToActivateRoadButton();

        }
        else
        {

            Debug.Log("max road Purchased!");
            uiController.EnableOrDisableTargetButton(uiController.AddRoad_Button, false);
            uiController.addRoadCost_Text.text = "MAX";

        }
    }
    private void CheckMaxCarsToMerge()
    {



        if (debugMergeCar.carCount_G == true && debugMergeCar.carCount_O == true && debugMergeCar.carCount_R == true)
        {

            //All lanes have maxed out with 3 cars 
            if (!uiController.MergeCar_Button.gameObject.activeSelf) uiController.MergeCar_Button.gameObject.SetActive(true);


            Debug.Log("Max merges!");
            uiController.EnableOrDisableTargetButton(uiController.MergeCar_Button, false);
            uiController.mergeCarCost_Text.text = "MAX";
        }
        else if (debugMergeCar.carCount_O && debugMergeCar.carCount_R)
        {
            //3 cars on orange lane && red lane 
            uiController.EnableOrDisableTargetButton(uiController.MergeCar_Button, false);

        }
        else if (debugMergeCar.carCount_O)
        {
            //3 cars on orange lane are ready for merge -> [red lane]
            if (debugMergeCar.R_road)
            {

                if (!uiController.MergeCar_Button.gameObject.activeSelf) uiController.MergeCar_Button.gameObject.SetActive(true);


                CheckWalletToActivateMergeButton();

            }
            else
            {
                //No road on [RedLane] for merge!
                //check if mergeButton is enable  ->  disabled it

                if (uiController.MergeCar_Button.gameObject.activeSelf) uiController.MergeCar_Button.gameObject.SetActive(false);

                uiController.EnableOrDisableTargetButton(uiController.MergeCar_Button, false);


            }

        }
        else if (debugMergeCar.carCount_G)
        {
            //3 cars on [green lane] are ready for merge -> [orange lane]

            if (debugMergeCar.O_road)
            {
                //check if road existis for merge [green lane]-> [orange lane]!

                //check if mergeButton is disabled ->  enable it
                if (!uiController.MergeCar_Button.gameObject.activeSelf) uiController.MergeCar_Button.gameObject.SetActive(true);

                CheckWalletToActivateMergeButton();

            }
            else
            {
                //No road on [OrangeLane] for merge!

                //check if mergeButton is enable  ->  disabled it
                if (uiController.MergeCar_Button.gameObject.activeSelf) uiController.MergeCar_Button.gameObject.SetActive(false);

                uiController.EnableOrDisableTargetButton(uiController.MergeCar_Button, false);

            }

        }

        else
        {
            if (uiController.MergeCar_Button.gameObject.activeSelf) uiController.MergeCar_Button.gameObject.SetActive(false);

            uiController.EnableOrDisableTargetButton(uiController.MergeCar_Button, false);

        }

    }
    private void CheckMaxRoadForIncome()
    {

        //targetStore




        if (greenStore.maxStoreInLaneActive && orangeStore.maxStoreInLaneActive && redStore.maxStoreInLaneActive)
        {
            Debug.Log("All max stores placed");
            uiController.EnableOrDisableTargetButton(uiController.Income_Button, false);
            uiController.incomeCost_Text.text = "MAX";


        }
        else if (!greenStore.maxStoreInLaneActive)
        {
            //Now you can only greenStores to be placed

            if (debugMergeCar.G_road)
            {
                //check if road placed ?
                targetStore = greenStore;
                CheckWalletToActivateIncomeButton();
            }
            else
            {
                Debug.Log("no green road to place store");
                uiController.EnableOrDisableTargetButton(uiController.Income_Button, false);

            }


        }
        else if (!orangeStore.maxStoreInLaneActive)
        {
            //Now you can only orangeStore to be placed

            if (debugMergeCar.O_road)
            {
                //check if road placed ?
                targetStore = orangeStore;
                CheckWalletToActivateIncomeButton();
            }
            else
            {
                Debug.Log("no orange road to place store");
                uiController.EnableOrDisableTargetButton(uiController.Income_Button, false);

            }
        }
        else if (!redStore.maxStoreInLaneActive)
        {
            //Now you can only redStore to be placed

            if (debugMergeCar.R_road)
            {
                //check if road placed ?
                targetStore = redStore;
                CheckWalletToActivateIncomeButton();
            }
            else
            {
                Debug.Log("no red road to place store");
                uiController.EnableOrDisableTargetButton(uiController.Income_Button, false);

            }
        }




    }


    private void CheckWalletToActivateCarBuyButton()
    {
        if (myWallet_Counter > 0 && myWallet_Counter >= carBuyRate)
        {
            uiController.EnableOrDisableTargetButton(uiController.AddCar_Button, true);
        }
        else
        {
            uiController.EnableOrDisableTargetButton(uiController.AddCar_Button, false);

        }
    }
    private void CheckWalletToActivateMergeButton()
    {
        if (myWallet_Counter > 0 && myWallet_Counter >= mergeBuyRate)
        {
            uiController.MergeCar_Button.gameObject.SetActive(true);
            uiController.EnableOrDisableTargetButton(uiController.MergeCar_Button, true);
        }
        else
        {
            uiController.MergeCar_Button.gameObject.SetActive(false);
            uiController.EnableOrDisableTargetButton(uiController.MergeCar_Button, false);

        }
    }
    private void CheckWalletToActivateIncomeButton()
    {
        if (myWallet_Counter > 0 && myWallet_Counter >= incomeBuyRate)
        {
            //we have cash to enable this button
            uiController.EnableOrDisableTargetButton(uiController.Income_Button, true);

        }
        else
        {
            uiController.EnableOrDisableTargetButton(uiController.Income_Button, false);

        }
    }
    private void CheckWalletToActivateRoadButton()
    {
        if (myWallet_Counter > 0 && myWallet_Counter >= roadBuyRate)
        {
            uiController.EnableOrDisableTargetButton(uiController.AddRoad_Button, true);
        }
        else
        {
            uiController.EnableOrDisableTargetButton(uiController.AddRoad_Button, false);

        }
    }

    public void OnAddButtonPressed()
    {
        CheckWalletForPurchacingACar(carBuyRate);



    }
    public void OnAddRoadButtonPressed()
    {
        CheckWalletForPurchacingRoad(roadBuyRate);


    }
    public void OnMergeButtonPressed()
    {
        CheckWalletForMerge(mergeBuyRate);
    }
    public void OnIncomeButtonPressed()
    {
        CheckWalletForIncome(incomeBuyRate);
    }

    private void CheckWalletForPurchacingACar(float amount)
    {

        if (myWallet_Counter >= amount)
        {
            //Purchase Success
            SubAmountFromWallet(amount);

            carBuyRate += carBuyRateAdder;

            uiController.DisplayCarCostUI(carBuyRate);

            G_debugAddCar.ProcessAddNewCar();

        }
        else
        {
            //Purchase Failed
        }
    }
    private void CheckWalletForPurchacingRoad(float amount)
    {

        if (myWallet_Counter >= amount)
        {
            //Purchase Success
            SubAmountFromWallet(amount);

            roadBuyRate += roadBuyRateAdder;

            uiController.DisplayRoadCostUI(roadBuyRate);

            debugRoadController.IncrementRoadActivation();

        }
        else
        {
            //Purchase Failed
        }
    }
    private void CheckWalletForMerge(float amount)
    {
        if (myWallet_Counter >= amount)
        {
            //Merge Success
            SubAmountFromWallet(amount);

            mergeBuyRate += mergeBuyRateAdder;

            uiController.DisplayMergeCostUI(mergeBuyRate);


            debugMergeCar.ProcessMerge();

        }
        else
        {
            //Merge Failed
        }
    }
    private void CheckWalletForIncome(float amount)
    {
        if (myWallet_Counter >= amount)
        {
            //Income Success
            SubAmountFromWallet(amount);

            incomeBuyRate += incomeBuyRateAdder;

            uiController.DisplayIncomeCostUI(incomeBuyRate);


            debugRoadController.IncrementStoreActivation(targetStore);


        }
        else
        {
            //Income Failed
        }
    }



    public void AddAmountToWallet(float amount)
    {

        myWallet_Counter += amount;



        uiController.DisplayWallettUI(myWallet_Counter);



    }
    public void SubAmountFromWallet(float amount)
    {
        if (myWallet_Counter > 0 || myWallet_Counter >= myWallet_Counter + amount)
        {
            myWallet_Counter -= amount;
        }
        else
        {
            Debug.Log("WALLET EMPTY");
        }

        uiController.DisplayCarCostUI(carBuyRate);
        uiController.DisplayMergeCostUI(mergeBuyRate);
        //
        uiController.DisplayWallettUI(myWallet_Counter);

    }


}

