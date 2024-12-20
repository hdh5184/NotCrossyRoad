using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovingMan_Script : MonoBehaviour
{
    // 큐브 이동 속도
    public float speed;

    // 큐브 이동 방향
    private int direction = 1;
    public float MaxZ = 14f, MinZ = -14f;
    //public float StartPos;

    void Start()
    {
        speed = Random.Range(7f, 15f);
        //StartPos = transform.position.z;
    }

    void Update()
    {
        if (transform.position.z <= MinZ)
        {
            direction = -1;
        }
        if (transform.position.z >= MaxZ)
        {
            direction = 1;
        }
        transform.Translate(Vector3.back * direction * speed * Time.deltaTime);
    }

}
