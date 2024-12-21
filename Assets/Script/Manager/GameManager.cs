using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public  GameManager     gm;

    /// <summary> 게임 오버 UI </summary>
    public  GameObject      UI_GameClear;
    /// <summary> 게임 완료 UI </summary>
    public  GameObject      UI_GameOver;

    /// <summary> 점수 표시 텍스트 </summary>
    public  TextMeshProUGUI ScoreText;
    /// <summary> 결과 출력 텍스트 </summary>
    public  TextMeshProUGUI ResultText;

    /// <summary> 게임 오버 유무 </summary>
    [SerializeField]
    private bool    isGameOver;

    /// <summary> 현재 게임의 점수 </summary>
    [SerializeField]
    private int     Score;

    private void Awake()
    {
        gm = this;
    }

    void Start()
    {
        Init();
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

        isGameOver = false;
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
        isGameOver = true;
        Time.timeScale = 0f;

        UI_GameOver.SetActive(true);
    }


    /// <summary>
    /// 게임을 완료한다.
    /// </summary>
    public void GameClear()
    {
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
}
