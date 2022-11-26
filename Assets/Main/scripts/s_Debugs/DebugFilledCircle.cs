using UnityEditor;
using UnityEngine;

public class DebugFilledCircle : MonoBehaviour
{
    public float size = 10.0f;
    [Range(1, 360)] public float angle = 10.0f;

    public float pathThickness = 2.0F;


    public Color myEdgeColor;
    public Color myPathColor;

    private void OnDrawGizmos()
    {


        //Handles.color = myEdgeColor;
        //Handles.DrawWireArc(transform.position, Vector3.up, Vector3.left * 10, angle, size);
        //
        //
        //Handles.color = myPathColor;
        //Handles.DrawWireDisc(transform.position, Vector3.up, size - 5F, pathThickness);



    }
}
