using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbstractionPosition : MonoBehaviour
{
    public Vector3 gizMosPosition = new Vector3(1,1,1);
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position,gizMosPosition);
    }

}
