using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool followX;
    public bool followY;
    public bool followZ;

    public Transform followTransform;
    public Vector3 offset;

    public float followSpeed;


    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(followX == true ? followTransform.position.x + offset.x : offset.x,
                                                followY == true ? followTransform.position.y + offset.y : offset.y,
                                                followZ == true ? followTransform.position.z + offset.z : offset.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}
