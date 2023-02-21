using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int currentScore;

    public Text scoreText;
    public void RaiseScore(int points)
    {
        this.currentScore += points;
    }
    private void FixedUpdate()
    {
        this.scoreText.text = this.currentScore.ToString();
    }
}
