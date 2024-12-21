using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Movement
{
    /// <summary> 플레이어가 보트 위에 대기하는지의 유무 </summary>
    public bool isOnBoat = false;

    protected override void Init()
    {
        MinSpeed = 4f;
        MaxSpeed = 12f;

        base.Init();
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
