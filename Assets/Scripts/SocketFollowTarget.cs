using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketFollowTarget : MonoBehaviour
{
    public Transform Target;
    public Vector3 offset;
    private void FixedUpdate()
    {
        transform.position = Target.position + Vector3.up * offset.y
            + Vector3.ProjectOnPlane(Target.right, Vector3.up).normalized * offset.x
            + Vector3.ProjectOnPlane(Target.forward, Vector3.up).normalized * offset.z;
    }
}
