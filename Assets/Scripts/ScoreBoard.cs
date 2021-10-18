using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    //I've added a line

    int score; // Default integers start at zero
    Text scoreText;

    
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int scorePerHit)
    {
        score = score + scorePerHit;
        scoreText.text = score.ToString();
    }
}
