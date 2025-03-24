using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public TMP_Text scoreText;
    private int score = 0;

    public int Score => score;

    void Start()
    {
        score = 0;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Points: " + score;
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScore();
    }

    public void SaveScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll(); // Clears all saved scores when the game closes
    }

}
