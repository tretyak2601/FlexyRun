using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] FlexyPlayer flexy;

    private int recordScore;
    private int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text = score.ToString();
        }
    }

    private void Awake()
    {
        flexy.OnBarrierPassed += IncreaseScore;
        recordScore = PlayerPrefs.GetInt(Constants.RECORD_SCORE);
        scoreText.text = recordScore.ToString();

        ResetScore();
    }

    private void SaveScore()
    {
        if (score > recordScore)
        {
            recordScore = score;
            PlayerPrefs.SetInt(Constants.RECORD_SCORE, recordScore);
        }
    }

    private void IncreaseScore()
    {
        Score++;
        SaveScore();
    }

    public void ResetScore()
    {
        Score = 0;
    }
}
