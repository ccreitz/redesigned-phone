using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGameController : MonoBehaviour {
    // Game stuff
    public int lives;
    public int score = 0;
    public int mult = 1;
    private bool paused;
    // UI stuff
    public UnityEngine.UI.Text livesCounter;
    public UnityEngine.UI.Text scoreCounter;
    public UnityEngine.UI.Text multCounter;
    private string livesFormat;
    private string scoreFormat;
    private string multFormat;
    public Transform gameOverStuff;
    public Transform pauseStuff;

    void Start () {
        livesFormat = livesCounter.text;
        scoreFormat = scoreCounter.text;
        multFormat = multCounter.text;
        paused = false;
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
        GameObject.FindGameObjectWithTag("MusicController").SetActive(false);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    public void Pause()
    {
        Debug.Log("Pause");
        paused = true;
        pauseStuff.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
        GameObject.FindWithTag("MusicController").GetComponent<MusicController>().Pause();
    }

    public void Unpause()
    {
        Debug.Log("Unpause");
        paused = false;
        pauseStuff.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        GameObject.FindWithTag("MusicController").GetComponent<MusicController>().Unpause();
    }

    private void OnDestroy()
    {
        Time.timeScale = 1.0f;
    }
}
