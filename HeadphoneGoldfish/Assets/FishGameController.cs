using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGameController : MonoBehaviour {
    public int lives;
    public int score;
    public UnityEngine.UI.Text livesCounter;
    public UnityEngine.UI.Text scoreCounter;
    public Transform gameOverStuff;

    void Start () {
        UpdateUI();
	}
	
	void Update () {
	}

    public void Damaged()
    {
        lives--;
        if (lives < 0)
        {
            GameOver();
        }
        else
        {
            UpdateUI();
        }
    }

    public void AddScore()
    {
        score++;
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
        livesCounter.text = lives.ToString();
        scoreCounter.text = score.ToString();
    }
}
