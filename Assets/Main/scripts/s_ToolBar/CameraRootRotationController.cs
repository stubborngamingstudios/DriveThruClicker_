using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraRootRotationController : MonoBehaviour
{
    public FixedJoystick YfixedJoystick;


    public Transform targetCamRoot;

    Quaternion startRotation;

    public float turnSpeed = 60F;
    //public TMP_InputField turnSpeed_inputField;
    Quaternion targetRot;

    private void Start()
    {
        startRotation = targetCamRoot.rotation;
    }
    void Update()
    {

        Quaternion y = Quaternion.AngleAxis(YfixedJoystick.Horizontal, Vector3.up);


        targetRot = Quaternion.Euler(0, y.y * turnSpeed, 0);

        targetCamRoot.rotation *= targetRot;

    }

    public void OnTurnSpeedUpdated()
    {
        //turnSpeed = float.Parse(turnSpeed_inputField.text);
    }

    public void OnResetCamPosRotPressed()
    {
        targetCamRoot.rotation = startRotation;
    }
}
