using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Movement
{
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
            Debug.Log("111");
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
