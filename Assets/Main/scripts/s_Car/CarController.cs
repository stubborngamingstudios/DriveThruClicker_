using KamaliDebug;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public enum carLaneMode { LaneGreen, LaneOrange, LaneRed }
    public carLaneMode carLaneStatus = carLaneMode.LaneGreen;
    public Transform pointToTrack;


    [Foldout("Anchors: "), ReadOnly] public Transform anchor1, anchor2, anchor3;
    [Foldout("Scripts: "), ReadOnly] public DebugCar anchor1Scrpt, anchor2Scrpt, anchor3Scrpt;
    [Foldout("Scripts: "), ReadOnly] public DebugPurchaseStats debugPurchaseStatsScrpt;
    [Foldout("Tags: "), Tag] public string a1_Tag, a2_Tag, a3_Tag;
    [Foldout("Tags: "), Tag] public string coffee_Tag, donut_Tag, burger_Tag;

    public float turnOffset = 90F;





    private void Start()
    {
        debugPurchaseStatsScrpt = FindObjectOfType<DebugPurchaseStats>();



        anchor1 = GameObject.FindGameObjectWithTag(a1_Tag).transform;
        anchor2 = GameObject.FindGameObjectWithTag(a2_Tag).transform;
        anchor3 = GameObject.FindGameObjectWithTag(a3_Tag).transform;

        anchor1Scrpt = anchor1.GetComponent<DebugCar>();
        anchor2Scrpt = anchor2.GetComponent<DebugCar>();
        anchor3Scrpt = anchor3.GetComponent<DebugCar>();



    }
    private void Update()
    {
        CheckSetFromLaneStaus();

        TrackPositionFromTarget(pointToTrack);
        TrackRotationFromTraget(pointToTrack);


    }





    private void CheckSetFromLaneStaus()
    {
        if (carLaneStatus == carLaneMode.LaneGreen)
        {
            TrackPositionFromTarget(anchor1);
            TrackRotationFromTraget(anchor1);
        }
        if (carLaneStatus == carLaneMode.LaneOrange)
        {
            TrackPositionFromTarget(anchor2);
            TrackRotationFromTraget(anchor2);
        }
        if (carLaneStatus == carLaneMode.LaneRed)
        {
            TrackPositionFromTarget(anchor3);
            TrackRotationFromTraget(anchor3);
        }
    }

    private void TrackPositionFromTarget(Transform trackTarget)
    {
        transform.position = trackTarget.position;
    }

    private void TrackRotationFromTraget(Transform rotTarget)
    {

        float y = rotTarget.eulerAngles.y + turnOffset;

        transform.rotation = Quaternion.Euler(transform.rotation.x, y, transform.rotation.z);
    }







    ScaleUpDo otherStoreDoScaleUp;

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(coffee_Tag))
        {
            //DebugX.Log(coffee_Tag + "  Store Visited:red,b;");
            debugPurchaseStatsScrpt.AddCoffeeCount();


            otherStoreDoScaleUp = other.GetComponentInChildren<ScaleUpDo>();
            otherStoreDoScaleUp.ProcessScaleUp();



        }
        if (other.gameObject.CompareTag(donut_Tag))
        {
            //DebugX.Log(donut_Tag + "  Store Visited:red,b;");
            debugPurchaseStatsScrpt.AddDonutCount();

            otherStoreDoScaleUp = other.GetComponentInChildren<ScaleUpDo>();
            otherStoreDoScaleUp.ProcessScaleUp();





        }
        if (other.gameObject.CompareTag(burger_Tag))
        {
            // DebugX.Log(burger_Tag + "  Store Visited:red,b;");
            debugPurchaseStatsScrpt.AddBurgerCount();

            otherStoreDoScaleUp = other.GetComponentInChildren<ScaleUpDo>();
            otherStoreDoScaleUp.ProcessScaleUp();




        }
    }




}
