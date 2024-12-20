using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score_Script : MonoBehaviour
{
    public int Score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ResultText;
    public GameObject ResultTextObject;
    string grade = "A+";
    void Start()
    {
        ScoreText.text = "Score : 0";
        //Score = 0;
    }

    void Update()
    {//18~ A+ / 15~17 A / 11~14 B / 8~10 C / 5~7 D / ~4 F
        if (Score >= 18) grade = "A+";
        else if (Score >= 15) grade = "A";
        else if (Score >= 11) grade = "B";
        else if (Score >= 8) grade = "C";
        else if (Score >= 5) grade = "D";
        else grade = "F";

        if (transform.position.x < -176)
        {
            ResultTextObject.SetActive(true);
            ResultText.text = "Score : " + Score.ToString() + "\nGrade : " + grade;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score"))
        {
            other.gameObject.SetActive(false);
            Score += 1;
            ScoreText.text = "Score : " + Score.ToString();
        }
    }
}
