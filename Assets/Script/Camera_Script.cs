using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Script : MonoBehaviour
{
    public Transform target; // 큐브의 Transform 컴포넌트

    public float smoothSpeed = 0.125f; // 카메라 이동 시 속도

    public Vector3 offset; // 카메라와 큐브 사이의 거리

    void Start()
    {
        offset = transform.position - target.transform.position;
        //transform.rotation = Quaternion.LookRotation(target.forward);
    }

    void LateUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;

        transform.position = desiredPosition;
        //transform.LookAt(target); // 카메라가 큐브를 바라보도…
    }
}