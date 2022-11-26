using KamaliDebug;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMergeCar : MonoBehaviour
{

    [BoxGroup("ActiveCars: ")] public bool carCount_G, carCount_O, carCount_R;
    [BoxGroup("ActiveRoadObjs: ")] public bool G_road, O_road, R_road;

    [BoxGroup("CarScripts: ")] public DebugAddCar G_debugAddCar;
    [BoxGroup("CarScripts: ")] public DebugAddCar O_debugAddCar;
    [BoxGroup("CarScripts: ")] public DebugAddCar R_debugAddCar;

    [BoxGroup("LaneScripts: ")] public DebugLaneController G_DebugLaneController;
    [BoxGroup("LaneScripts: ")] public DebugLaneController O_DebugLaneController;
    [BoxGroup("LaneScripts: ")] public DebugLaneController R_DebugLaneController;


    [BoxGroup("RoadObjs: ")] public GameObject G_RoadObj;
    [BoxGroup("RoadObjs: ")] public GameObject O_RoadObj;
    [BoxGroup("RoadObjs: ")] public GameObject R_RoadObj;


    //public int index = -1;

    [ReadOnly] public UIController uiController;



    private void Update()
    {

        ActiveCarOnLanes(G_DebugLaneController, O_DebugLaneController, R_DebugLaneController);
        CheckRoadForMerge();
    }




    private void ActiveCarOnLanes(DebugLaneController g, DebugLaneController o, DebugLaneController r)
    {
        if (g.activeCarCount > 1) carCount_G = true; else carCount_G = false;
        if (o.activeCarCount > 1) carCount_O = true; else carCount_O = false;
        if (r.activeCarCount > 1) carCount_R = true; else carCount_R = false;
    }





    public void CheckRoadForMerge()
    {

        if (G_RoadObj.activeSelf) G_road = true; else G_road = false;
        if (O_RoadObj.activeSelf) O_road = true; else O_road = false;
        if (R_RoadObj.activeSelf) R_road = true; else R_road = false;


    }



    [Button]
    public void ProcessMerge()
    {

        //TODO: CHECK IF ROAD EXISITS FOR MERGE?



        if (carCount_G == true && carCount_O == false)
        {
            GreenToOrangeMerge();
        }
        if (carCount_O == true && carCount_R == false)
        {
            OrangeToRedMerge();
        }



    }


    public void GreenToOrangeMerge()
    {

        if (O_DebugLaneController.activeCarCount < 2)
        {

            if (G_debugAddCar.addCarIndex != 2) return;

            G_debugAddCar.addCarIndex = -1;

            G_debugAddCar.DisableAllCars();


            O_debugAddCar.ProcessAddNewCar();
            DebugX.Log("You have merged cars!:cyan:b;");
        }
        else
        {
            DebugX.Log("Cannot merged cars!No Empty lane!:magenta:b;");

        }
    }

    public void OrangeToRedMerge()
    {
        if (R_DebugLaneController.activeCarCount < 2)
        {

            if (O_debugAddCar.addCarIndex != 2) return;

            O_debugAddCar.addCarIndex = -1;

            O_debugAddCar.DisableAllCars();


            R_debugAddCar.ProcessAddNewCar();
            DebugX.Log("You have merged cars!:cyan:b;");
        }
        else
        {
            DebugX.Log("Cannot merged cars!No Empty lane!:magenta:b;");

        }
    }
}



