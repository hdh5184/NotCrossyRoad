using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : Movement
{
    [Header("Ride Player")]
    /// <summary> 플레이어 위치 이동용 Transform </summary>
    [SerializeField]
    private Transform   transform_Player;

    [Header("Boat State")]
    /// <summary> 플레이어가 보트 위에 탑승중인지의 유무 </summary>
    [SerializeField]
    private bool        isRidePlayer = false;


    protected override void Update()
    {
        base.Update();

        RidePlayer();
    }


    /// <summary>
    /// 게임 시작 시 보트 속성을 초기화한다.
    /// </summary>
    protected override void Init()
    {
        MinSpeed = 4f;
        MaxSpeed = 12f;

        base.Init();
    }


    /// <summary>
    /// 보트를 태우는 플레이어를 지정한다.
    /// </summary>
    /// <param name="player"> 플레이어의 Transform </param>
    public void MeetPlayer(Transform player)
    {
        transform_Player    = player;
        isRidePlayer        = true;
    }


    /// <summary>
    /// 보트를 태우는 플레이어를 지정한다.
    /// </summary>
    /// <param name="player"> 플레이어 속성을 가진 오브젝트 </param>
    public void MeetPlayer(Player player)
    {
        transform_Player    = player.transform;
        isRidePlayer        = true;
    }


    /// <summary>
    /// 플레이어가 보트로부터 떨어진다.
    /// </summary>
    public void UnMeetPlayer()
    {
        transform_Player    = null;
        isRidePlayer        = false;
    }


    /// <summary>
    /// 보트를 탄 플레이어를 이동시킨다.
    /// </summary>
    private void RidePlayer()
    {
        if (!isRidePlayer) return;

        transform_Player.Translate(moveVec * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Playerrrr")
        {
            isRidePlayer = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Playerrrr")
        {
            isRidePlayer = false;
        }
    }
}
