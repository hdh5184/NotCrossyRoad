using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Movement
{
    /// <summary>
    /// 게임 시작 시 차량 속성을 초기화한다.
    /// </summary>
    protected override void Init()
    {
        MinSpeed = 7f;
        MaxSpeed = 15f;

        base.Init();
    }
}
