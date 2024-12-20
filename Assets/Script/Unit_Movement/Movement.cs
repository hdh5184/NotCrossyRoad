using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    protected   float   speed;
    [SerializeField]
    protected   Vector3 moveVec;
    [SerializeField]
    protected   bool    isRunRight;

    public      float   MinSpeed = 7f;
    public      float   MaxSpeed = 15f;

    public      float   MinZ = -14;
    public      float   MaxZ = 14;

    void Start()
    {
        Init();
    }

    void Update()
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
