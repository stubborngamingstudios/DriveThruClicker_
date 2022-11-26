using DG.Tweening;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlyDo : MonoBehaviour
{

    public float flyDuriation = 0.5F;

    public float fadeInDuriation = 0.1F;
    public float fadeOutDuriation = 0.5F;


    public float endYPos;
    Vector3 startPos;

    [ReadOnly] public TextMeshProUGUI popText;



    private void Start()
    {

        startPos = transform.position;

        popText.color = new Color(popText.color.r, popText.color.g, popText.color.b, 0);
        LookToCamera();
    }

    [Button]
    public void ProcessFly()
    {
        if (DOTween.IsTweening(transform)) return;

        ResetPos();



        //var sequence = DOTween.Sequence();
        //sequence.Append(transform.DOMove(new Vector3(transform.position.x, transform.position.y + endYPos, transform.position.z), flyDuriation));
        //sequence.Join(popText.DOFade(0, fadeDuriation)).onComplete = SlowFade;
        //sequence.onComplete = ResetPos;


        transform.DOMove(new Vector3(transform.position.x, transform.position.y + endYPos, transform.position.z), flyDuriation);
        popText.DOFade(1, flyDuriation).onComplete = SlowFade;
    }

    private void ResetPos()
    {
        transform.position = startPos;
        popText.DOFade(0, 0.1F);



    }
    private void SlowFade()
    {
        popText.DOFade(0, fadeOutDuriation);

    }

    private void Update()
    {
        LookToCamera();
    }


    public void LookToCamera()
    {
        transform.LookAt(Camera.main.transform);
    }

}
