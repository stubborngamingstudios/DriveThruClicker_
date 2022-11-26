using NaughtyAttributes;
using UnityEditor;
using UnityEngine;


public class DebugCar : MonoBehaviour
{
    public float anchorSpeed;
    public float anchorDistFromPointCenter;

    [ReadOnly] public float def_anchorSpeed;
    [ReadOnly] public float max_anchorSpeed;


    [ReadOnly] public Transform pointCenter;
    [ReadOnly] public DebugInputSystem debugInputSystem;

    public float angle;
    public float radius;


    [Foldout("Arc: ")] public Transform targetToMoveAngle;
    [Foldout("Arc: ")] public Vector3 endAnglePos;
    [Foldout("Arc: ")] public Color myArcColor;





    private void Start()
    {
        def_anchorSpeed = anchorSpeed;

        pointCenter = GameObject.FindGameObjectWithTag("Center").transform;
        debugInputSystem = FindObjectOfType<DebugInputSystem>();

        max_anchorSpeed = def_anchorSpeed + debugInputSystem.touchCarSpeedMultiplier;
    }




    void Update()
    {

        CheckSpeedInput();

        transform.RotateAround(pointCenter.position, Vector3.up, anchorSpeed * Time.deltaTime);

    }


    void CheckSpeedInput()
    {
        if (debugInputSystem.screenTouched)
        {
            anchorSpeed = max_anchorSpeed;
        }
        else
        {
            anchorSpeed = def_anchorSpeed;
        }
    }

    #region SetAnchorToRandomPosFromAngle
    private void SetRandomAnchorPos()
    {
        transform.position = RandomPointOnXZCircle(pointCenter.position, anchorDistFromPointCenter);

    }
    Vector3 RandomPointOnXZCircle(Vector3 center, float radius)
    {
        float angle = Random.Range(0, 2f * Mathf.PI);
        return center + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
    }

    #endregion

    #region MoveTargetToPosFromAngle
    [Button]
    private void SetEnd()
    {
        endAnglePos = GetPosition(angle, anchorDistFromPointCenter);
        targetToMoveAngle.position = endAnglePos;

    }
    Vector3 GetPosition(float angle, float dist)
    {
        float a = angle * Mathf.PI / 180f;
        return new Vector3(Mathf.Sin(a) * dist, 0, Mathf.Cos(a) * dist);
    }

    #endregion







    void OnDrawGizmosSelected()
    {

        //Handles.Label(transform.position + Vector3.left * 4, transform.name);
        //
        //Handles.color = myArcColor;
        //Handles.DrawSolidArc(Vector3.zero, Vector3.up, transform.position, angle, radius);


    }





}
