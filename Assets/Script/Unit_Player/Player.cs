using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어 클래스
/// </summary>
public class Player : MonoBehaviour
{
    [Header("GameManager")]
    public  GameManager gm;

    [Header("Component")]
    [SerializeField]
    private Rigidbody   rg;

    /// <summary> 플레이어가 탑승하는 보트 </summary>
    private Boat        ridingBoat;


    [Header("Player State")]
    /// <summary> 플레이어의 점프 여부 </summary>
    [SerializeField]
    private bool        isJumping;
    /// <summary> 플레이어의 보트 탑승 여부 </summary>
    [SerializeField]
    private bool        isOnBoat;

    void Start()
    {
        Init();
    }

    
    void Update()
    {
        if (!gm.Check_IsGamePlay()) return;

        Jump();
    }


    /// <summary>
    /// 게임 시작 시 플레이어 속성을 초기화한다.
    /// </summary>
    private void Init()
    {
        ridingBoat  = null;

        isJumping   = false;
        isOnBoat    = false;
    }


    /// <summary>
    /// 플레이어가 제자리에서 뛰며 이동한다.
    /// </summary>
    private void Jump()
    {
        if (isJumping) return;

        if      (Input.GetKeyDown(KeyCode.UpArrow))     JumpForKeyDown('U');
        else if (Input.GetKeyDown(KeyCode.DownArrow))   JumpForKeyDown('D');
        else if (Input.GetKeyDown(KeyCode.LeftArrow))   JumpForKeyDown('L');
        else if (Input.GetKeyDown(KeyCode.RightArrow))  JumpForKeyDown('R');
    }


    /// <summary>
    /// 방향키 입력 시 해당 키의 방향으로 플레이어가 이동한다.
    /// </summary>
    /// <param name="key">
    /// 입력한 방향키에 따른 문자(U : 상, D : 하, L : 좌, R : 우)
    /// </param>
    private void JumpForKeyDown(char key)
    {
        isJumping = true;

        if (isOnBoat) UnMeetBoat();

        switch (key)
        {
            case 'U':   rg.velocity = new Vector3(-10, 1.5f, 0);    break;
            case 'D':   rg.velocity = new Vector3(10, 1.5f, 0);     break;
            case 'L':   rg.velocity = new Vector3(0, 1.5f, -10);    break;
            case 'R':   rg.velocity = new Vector3(0, 1.5f, 10);     break;
        }
    }


    /// <summary>
    /// 플레이어가 착지 시 이동 힘을 해제한다.
    /// </summary>
    private void Land()
    {
        rg.velocity = Vector3.zero;
        rg.angularVelocity = Vector3.zero;
        isJumping = false;
    }


    /// <summary>
    /// 올라탄 보트에 플레이어 transform을 전달한다.
    /// </summary>
    /// <param name="boat"> 보트의 Collision </param>
    private void MeetBoat(Collision boat)
    {
        isOnBoat    = true;

        ridingBoat  = boat.gameObject.GetComponent<Boat>();
        ridingBoat.MeetPlayer(transform);
    }


    /// <summary>
    /// 올라탄 보트로부터 빠진다.
    /// </summary>
    private void UnMeetBoat()
    {
        ridingBoat.UnMeetPlayer();
        ridingBoat  = null;

        isOnBoat    = false;
    }


    /// <summary>
    /// 올라탄 보트에 플레이어 transform을 전달한다.
    /// </summary>
    /// <param name="boat"> 보트 오브젝트 </param>
    private void MeetBoat(GameObject boat)
    {
        boat.GetComponent<Boat>().MeetPlayer(transform);
        //boat.gameObject.GetComponent<Boat>().MeetPlayer(this);
    }


    /// <summary>
    /// 플레이어가 점수 아이템을 획득한다.
    /// </summary>
    /// <param name="score"> 점수 아이템 오브젝트의 Collider </param>
    private void GetScore(Collider score)
    {
        score.gameObject.SetActive(false);
        gm.IncreaseScore();
    }


    /// <summary>
    /// 플레이어가 점수 아이템을 획득한다.
    /// </summary>
    /// <param name="score"> 점수 아이템 오브젝트 </param>
    private void GetScore(GameObject score)
    {
        score.SetActive(false);
        gm.IncreaseScore();
    }


    /// <summary>
    /// 플레이어가 가장자리에 도달 시 이동 반대 방향으로 힘을 반사한다.
    /// </summary>
    /// <param name="arrow">
    /// 도달한 가장자리 위치에 따른 문자(L : 좌, R : 우, B : 후방)
    /// </param>
    private void OverEdge(char arrow)
    {
        switch (arrow)
        {
            case 'L': rg.velocity = new Vector3(0, 0, 2f);  break;
            case 'R': rg.velocity = new Vector3(0, 0, -2f); break;
            case 'B': rg.velocity = new Vector3(-2f, 0, 0); break;
        }
    }


    /// <summary>
    /// 플레이어의 위치를 지정한다.
    /// </summary>
    /// <param name="pos"> 플레이어 위치를 지정할 좌표 Vector </param>
    public void SetPosition(Vector3 pos) => transform.position = pos;


    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Score"))
        GetScore(collision);
        //GetScore(collision.gameObject);
    }

    private void OnTriggerStay(Collider collision)
    {
        switch (collision.gameObject.tag)
        {
            case "River"
            when !gm.debugText_NoDrown:
            gm.GameOver(); break;

            case "Car"
            when !gm.Debug_isPlayerNotHit:
            gm.GameOver(); break;

            case "Goal":    gm.GameClear();
                            rg.velocity = new Vector3(100f, 20f, 0); break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Floor":       
            case "River":       Land();                 break;

            case "Boat":        Land();
                                MeetBoat(collision);    break;

            case "WallLeft":    OverEdge('L');  break;
            case "WallRight":   OverEdge('R');  break;
            case "WallBack":    OverEdge('B');  break;
        }
    }
}
