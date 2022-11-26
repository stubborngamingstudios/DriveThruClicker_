using DG.Tweening;
using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScaleUpDo : MonoBehaviour
{

    public Vector3 scaleTarget = new Vector3(0, 0.5F, 0);
    [ReadOnly] public FlyDo myFlyDo;

    public static event Action onCashGaied;

    [Button]
    public void ProcessScaleUp()
    {

        //is called from car controller

        transform.DORewind();
        transform.DOPunchScale(scaleTarget, .25f);



        //TODO:  fade effect + update store number buy store gain value
        if (myFlyDo != null) myFlyDo.ProcessFly();


        onCashGaied?.Invoke();


    }






}
