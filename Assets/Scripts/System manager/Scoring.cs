using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public static int totalScore = 0;
    public int HighScore;
    public TextMeshProUGUI scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        //scoreboard = GetComponent<TextMeshProUGUI>();
        HighScore = totalScore;

    }

   
    public void Update()
    {
        setScore();
    }

    public void setScore()
    {
        scoreboard.text = totalScore.ToString();
    }
    // Update is called once per frame
    /*public void SetScore(int score)
    {
        score += currentScore;
        scoreboard.text = totalScore.ToString();
    }*/
}
