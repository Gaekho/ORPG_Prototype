using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float smoothTime;
    private Vector3 targetPosition;
    private Vector3 lastMovingVelocity;
    private void Move(){
        targetPosition = target.transform.position;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref lastMovingVelocity, smoothTime);
        transform.position = smoothPosition;
    }
    

    void FixedUpdate()
    {
        if(target != null) {
            Move();
        }
    }
}
