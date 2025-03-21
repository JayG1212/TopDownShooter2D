using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using  UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public TMP_Text highScoreText; // Assign this in the Inspector

    void Start()
    {
        int recentScore = PlayerPrefs.GetInt("RecentScore", 0);  // Get the saved score (defaults to 0 if not found)
        highScoreText.text = "Your Score: " + recentScore;

    }

}
