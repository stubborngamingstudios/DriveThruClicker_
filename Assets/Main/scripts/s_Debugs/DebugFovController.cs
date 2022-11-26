
using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugFovController : MonoBehaviour
{

    public Camera myCam;
    public GameModeController gameModeController;
    public DebugRoadController debugroadController;

    public List<float> myFovs = new List<float>();
    //public float zoomSpeed = 3F;


    public bool isTween;
    [ShowIf("isTween")] public float zoomDuriation = 0.15F;
    [ShowIf("isTween")] public Ease zoomEase;


    public void Update()
    {
        if (gameModeController.gameState == GameModeController.gameMode.play)
        {
            if (debugroadController.activeRoadIndex == 1)
            {
                //second lane/road
                //myCam.fieldOfView = Mathf.MoveTowards(myCam.fieldOfView, myFovs[1], Time.deltaTime * zoomSpeed);

                ProcessCamTween(myCam, myFovs[1], zoomDuriation, zoomEase);

            }
            if (debugroadController.activeRoadIndex == 2)
            {
                //third lane/road
                //myCam.fieldOfView = Mathf.MoveTowards(myCam.fieldOfView, myFovs[2], Time.deltaTime * zoomSpeed);
                ProcessCamTween(myCam, myFovs[2], zoomDuriation, zoomEase);

            }

        }
    }


    private void ProcessCamTween(Camera cam, float taregtFov, float dur, Ease targetEase)
    {
        cam.DOFieldOfView(taregtFov, dur).SetEase(targetEase);
    }



}
