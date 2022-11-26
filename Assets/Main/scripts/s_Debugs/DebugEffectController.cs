using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugEffectController : MonoBehaviour
{
    [ReadOnly] public FlyDo flyDo;
    [ReadOnly] public ScaleUpDo scaleUpDo;
    TextMeshProUGUI popText;
    public Canvas popCanvas;

    AudioSource myCashAudioSource;
    public AudioClip myCashAudioClip;


    private void Awake()
    {
        flyDo = GetComponentInChildren<FlyDo>();
        scaleUpDo = GetComponentInChildren<ScaleUpDo>();
        popText = popCanvas.GetComponentInChildren<TextMeshProUGUI>();
        popCanvas.transform.localPosition = new Vector3(0, popCanvas.transform.localPosition.y, scaleUpDo.transform.localPosition.z);
        scaleUpDo.myFlyDo = flyDo;
        flyDo.popText = popText;
    }



}
