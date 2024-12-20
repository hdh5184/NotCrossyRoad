using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Movement
{
    protected override void Init()
    {
        MinSpeed = 7f;
        MaxSpeed = 15f;

        base.Init();
    }
}
