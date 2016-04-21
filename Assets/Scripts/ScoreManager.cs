using UnityEngine;
using System.Collections;

public class ScoreManager : SingletonMonobehaviour<ScoreManager>
{
    private int maxScore;

    void Awake()
    {
        maxScore = PlayerPrefs.GetInt("HighScore");
        Debug.Log(maxScore);
    }

	public int GetHighScore()
    {
        return maxScore;
    }

    public void SetHighScore(int highScore)
    {
        if(highScore > maxScore)
        {
            maxScore = highScore;
            PlayerPrefs.SetInt("HighScore", maxScore);
        }
    }

    public void Save()
    {
        PlayerPrefs.Save();
        Debug.Log("Highscore Saved");
    }

    void OnDestroy()
    {
        Save();
    }
}
