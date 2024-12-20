using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Script : MonoBehaviour
{
    public GameObject Player;

    // 큐브 이동 속도
    public float speed;

    // 큐브 이동 방향
    private int direction = 1;
    public float MaxZ = 13f, MinZ = -13f;
    public bool isOnBoat = false;
    //public float StartPos;

    void Start()
    {
        speed = Random.Range(4f, 12f);
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

        if (isOnBoat)
        {
            Player.transform.Translate(Vector3.back * direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Playerrrr")
        {
            isOnBoat = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Playerrrr")
        {
            isOnBoat = false;
        }
    }
}
