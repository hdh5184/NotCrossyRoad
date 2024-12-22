using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public  Player          m_Player;


    [Header("UI")]
    /// <summary> 게임 오버 UI </summary>
    public  GameObject      UI_GameClear;
    /// <summary> 게임 완료 UI </summary>
    public  GameObject      UI_GameOver;

    [Header("UI : Text")]
    /// <summary> 점수 표시 텍스트 </summary>
    public  TextMeshProUGUI ScoreText;
    /// <summary> 결과 출력 텍스트 </summary>
    public  TextMeshProUGUI ResultText;

    [Header("UI : Debug")]
    /// <summary> 디버그 : 플레이어 차량 충돌 무시 Text </summary>
    public  TextMeshProUGUI debugText_NoHit;
    /// <summary> 디버그 : 플레이어 차량 충돌 무시 Text </summary>
    public  TextMeshProUGUI debugText_NoDrown;


    [Header("Game State")]
    /// <summary> 게임 진행 유무 </summary>
    [SerializeField]
    private bool    isGamePlay;


    [Header("Score")]
    /// <summary> 현재 게임의 점수 </summary>
    [SerializeField]
    private int     Score;


    [Header("Debug")]
    /// <summary> 디버그 : 플레이어의 차량 충돌 무시 여부 </summary>
    [SerializeField]
    private bool    debug_isPlayerNotHit;
    public  bool    Debug_isPlayerNotHit => debug_isPlayerNotHit;
    /// <summary> 디버그 : 플레이어의 강 입수 무시 여부 </summary>
    [SerializeField]
    private bool    debug_isPlayerNotDrown;
    public  bool    Debug_isPlayerNotDrown => debug_isPlayerNotDrown;


    void Start()
    {
        Init();
    }

    private void Update()
    {
        if (!Check_IsGamePlay()) return;

        Check_Debug();
    }


    /// <summary>
    /// 게임 속성을 초기화한다.
    /// </summary>
    private void Init()
    {
        Score = 0;

        UI_GameClear.SetActive(false);
        UI_GameOver.SetActive(false);

        ScoreText.text  = "Score : 0";
        ResultText.text = string.Empty;

        isGamePlay      = true;

        debug_isPlayerNotHit = false;
    }


    /// <summary>
    /// 현재 게임이 진행되는 지 확인한다.
    /// </summary>
    /// <returns>
    /// 게임 진행 중이면 true, 아니면 false를 반환한다.
    /// </returns>
    public bool Check_IsGamePlay()
    {
        if (!isGamePlay)    return false;
        else                return true;
    }


    /// <summary>
    /// 점수를 증가한다.
    /// </summary>
    public void IncreaseScore()
    {
        Score++;
        ScoreText.text = $"Score : {Score}";
    }


    /// <summary>
    /// 게임을 실패한다.
    /// </summary>
    public void GameOver()
    {
        isGamePlay      = false;
        Time.timeScale  = 0f;

        UI_GameOver.SetActive(true);
    }


    /// <summary>
    /// 게임을 완료한다.
    /// </summary>
    public void GameClear()
    {
        isGamePlay      = false;

        ResultText.text =
            $"Score : {Score}\n" +
            $"Grade : {GetGrade(Score)}";

        UI_GameClear.SetActive(true);
    }


    /// <summary>
    /// 게임을 재시작한다.
    /// </summary>
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


    /// <summary>
    /// 게임 완료 시 성적을 산출한다.
    /// </summary>
    /// <param name="Score">
    /// 성적을 산출하는 데 필요한 점수
    /// </param>
    /// <returns>
    /// 현재 점수(Score)에 따른 성적을 반환한다. (18~ : A+ / 15~17 : A / 11~14 : B / 8~10 : C / 5~7 : D / 그 외 : F)
    /// </returns>
    public string GetGrade(in int Score)
    {
        if (Score >= 18)    return "A+";
        if (Score >= 15)    return "A";
        if (Score >= 11)    return "B";
        if (Score >= 8)     return "C";
        if (Score >= 5)     return "D";
        else                return "F";
    }


    /// <summary>
    /// * 디버그 관리 메서드
    /// </summary>
    private void Check_Debug()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            m_Player.SetPosition(new Vector3(-175.3f, 0.5f, 0));
            Debug.Log("디버그 : 플레이어를 도착 지점으로 이동");
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            debug_isPlayerNotHit = !debug_isPlayerNotHit;
            debugText_NoHit.gameObject.SetActive(debug_isPlayerNotHit);

            Debug.Log($"디버그 : 플레이어 차량 충돌 무시 {(debug_isPlayerNotHit ? "활성화" : "비활성화")}");
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            debug_isPlayerNotDrown = !debug_isPlayerNotDrown;
            debugText_NoDrown.gameObject.SetActive(debug_isPlayerNotDrown);

            Debug.Log($"디버그 : 플레이어 강 입수 무시 {(debug_isPlayerNotDrown ? "활성화" : "비활성화")}");
        }
    }
}
