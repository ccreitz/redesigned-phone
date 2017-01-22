using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGameController : MonoBehaviour {
    // Game stuff
    public int lives;
    public int score = 0;
    public int mult = 1;
    // UI stuff
    public UnityEngine.UI.Text livesCounter;
    public UnityEngine.UI.Text scoreCounter;
    public UnityEngine.UI.Text multCounter;
    private string livesFormat;
    private string scoreFormat;
    private string multFormat;
    public Transform gameOverStuff;

    void Start () {
        livesFormat = livesCounter.text;
        scoreFormat = scoreCounter.text;
        multFormat = multCounter.text;
        UpdateUI();
	}
	
    public void Damaged()
    {
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            mult = 1;
            lives--;
            UpdateUI();
        }
    }

    public void AddScore()
    {
        score += mult;
        UpdateUI();
    }

    public void AddMult()
    {
        mult++;
        UpdateUI();
    }

    public void SubMult()
    {
        mult--;
        mult = mult > 1 ? mult : 1;
        UpdateUI();
    }

    void GameOver()
    {
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        WaveDetector.Instance.gameObject.SetActive(false);
        gameOverStuff.gameObject.SetActive(true);
        if (score > PlayerPrefs.GetInt("score", 0))
        {
            PlayerPrefs.SetInt("score", score);
        }
    }

    void UpdateUI()
    {
        livesCounter.text = string.Format(livesFormat, lives);
        scoreCounter.text = string.Format(scoreFormat, score);
        multCounter.text = string.Format(multFormat, mult);
    }
}
