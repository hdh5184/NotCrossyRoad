using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Move")]
    /// <summary> 이동 속도 </summary>
    [SerializeField]
    protected   float   speed;
    /// <summary> 이동 방향 </summary>
    [SerializeField]
    protected   Vector3 moveVec;
    /// <summary> 우측 이동의 유무 </summary>
    [SerializeField]
    protected   bool    isRunRight;


    [Header("Move Limit")]
    /// <summary> 초기 설정 시 최소 이동 속도 </summary>
    public      float   MinSpeed = 7f;
    /// <summary> 초기 설정 시 최대 이동 속도 </summary>
    public      float   MaxSpeed = 15f;
    /// <summary> 좌측 필드 경계 값 </summary>
    public      float   MinZ = -14;
    /// <summary> 우측 필드 경계 값 </summary>
    public      float   MaxZ = 14;


    protected void Start()
    {
        Init();
    }

    protected virtual void Update()
    {
        Check_Turn();

        Run();
    }


    /// <summary>
    /// 게임 시작 시 자동차 속성을 초기화한다.
    /// </summary>
    protected virtual void Init()
    {
        speed       = Random.Range(MinSpeed, MaxSpeed);
        moveVec     = Vector3.back * speed;
        isRunRight  = true;
    }


    /// <summary>
    /// 자동차가 반대로 돌아가는 지 검사한다.
    /// </summary>
    protected void Check_Turn()
    {
        if (IsOverEdge()) moveVec *= -1;
    }


    /// <summary>
    /// 자동차가 달리는 방향으로 위치를 이동한다.
    /// </summary>
    protected void Run()
    {
        transform.Translate(moveVec * Time.deltaTime);
    }


    /// <summary>
    /// 자동차가 도로 필드 경계(좌표 z)에 도달하는 지 검사한다.
    /// </summary>
    /// <returns>
    /// 필드 경계에 도달 시 true, 미도달 시 false 반환
    /// </returns>
    protected bool IsOverEdge()
    {
        if (isRunRight && transform.position.z <= MinZ)
        {
            isRunRight = false;
            return true;
        }

        if (!isRunRight && transform.position.z >= MaxZ)
        {
            isRunRight = true;
            return true;
        }

        return false;
    }
}
