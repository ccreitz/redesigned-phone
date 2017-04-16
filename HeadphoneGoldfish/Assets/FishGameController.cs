using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGameController : MonoBehaviour {
    // Game stuff
    public int score = 0;
    public int mult = 1;
    private bool paused;
    // UI stuff
    public UnityEngine.UI.Text attemptsCounter;
    public UnityEngine.UI.Text scoreCounter;
    public UnityEngine.UI.Text multCounter;
    private string attemptsFormat;
    private string scoreFormat;
    private string multFormat;
    public Transform gameOverStuff;
    public Transform pauseStuff;

    void Start () {
        attemptsFormat = attemptsCounter.text;
        scoreFormat = scoreCounter.text;
        multFormat = multCounter.text;
        paused = false;
        UpdateUI();
	}
	
    public void Damaged()
    {
        GameOver();
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
        int attempts = 0;
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        WaveDetector.Instance.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("MusicController").SetActive(false);
        gameOverStuff.gameObject.SetActive(true);
        attempts = PlayerPrefs.GetInt("attempts");
        Debug.Log("attempts" + attempts);
        attempts++;
        PlayerPrefs.SetInt("attempts", attempts);
        if (score > PlayerPrefs.GetInt("score", 0))
        {
            PlayerPrefs.SetInt("score", score);
        }
    }

    void UpdateUI()
    {
        attemptsCounter.text = string.Format(attemptsFormat, PlayerPrefs.GetInt("attempts", 0));
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
