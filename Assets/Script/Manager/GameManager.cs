using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public  GameManager     gm;

    public  TextMeshProUGUI ScoreText;
    public  TextMeshProUGUI ResultText;

    [SerializeField]
    private int Score;

    private void Awake()
    {
        gm = this;
    }

    void Start()
    {
        Init();
    }

    void Update()
    {
        
    }

    private void Init()
    {
        Score = 0;

        ScoreText.text  = "Score : 0";
        ResultText.text = string.Empty;
    }

    public void IncreaseScore()
    {
        Score += 1;
        ScoreText.text = $"Score : {Score}";
    } 

    public void GameClear()
    {
        ResultText.text =
            $"Score : {Score}\n" +
            $"Grade : {GetGrade(Score)}";

        ResultText.gameObject.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }



    public string GetGrade(in int Score)
    {
        //18~ : A+ / 15~17 : A / 11~14 : B / 8~10 : C / 5~7 : D / ~4 : F

        if (Score >= 18)    return "A+";
        if (Score >= 15)    return "A";
        if (Score >= 11)    return "B";
        if (Score >= 8)     return "C";
        if (Score >= 5)     return "D";
        else                return "F";
    }
}
