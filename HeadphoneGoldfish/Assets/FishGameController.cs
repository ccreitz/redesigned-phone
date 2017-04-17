using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGameController : MonoBehaviour {
    // Game stuff
    public int score = 0;
    public int mult = 1;
    private bool paused;
	private bool gameOver = false;
    // UI stuff
    public UnityEngine.UI.Text attemptsCounter;
    public UnityEngine.UI.Text scoreCounter;
    public UnityEngine.UI.Text multCounter;
    public UnityEngine.UI.Text highScore1;
    public UnityEngine.UI.Text highScore2;
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
		gameOver = false;
        UpdateUI();
	}
	
    public void Damaged()
    {
        FishCharacter character = (FishCharacter) GameObject.FindGameObjectWithTag ("Player").GetComponent (typeof(FishCharacter));
        if (!character.isInv())
        {
    		character.die ();
    		gameOver = true;
			GameObject.FindWithTag("MusicController").GetComponent<MusicController>().Pause();
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
        int attempts = 0;
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
		WaveDetector.Instance.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("MusicController").SetActive(false);
        gameOverStuff.gameObject.SetActive(true);
        attempts = PlayerPrefs.GetInt("attempts");
        Debug.Log("score" + PlayerPrefs.GetInt("score", score));
        attempts++;
        PlayerPrefs.SetInt("attempts", attempts);
        if (score > PlayerPrefs.GetInt("score", 0))
        {
            PlayerPrefs.SetInt("score", score);
            highScore1.text = PlayerPrefs.GetInt("score", score).ToString();
        }
        else
        {
            highScore1.text = PlayerPrefs.GetInt("score", score).ToString();
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
		if (!paused) {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			if (player != null) {
				
				FishCharacter character = player.transform.GetComponent<FishCharacter> ();
				if (character != null) {
					if (character.isDead ()) {
						GameOver ();
					}
				}
			}
		}
    }

    public void Pause()
    {
        Debug.Log(PlayerPrefs.GetInt("score"));
        Debug.Log("Pause");
        if (score > PlayerPrefs.GetInt("score", 0))
        {
            PlayerPrefs.SetInt("score", score);
            highScore2.text = PlayerPrefs.GetInt("score", score).ToString();
        }
        else
        {
            highScore2.text = PlayerPrefs.GetInt("score", score).ToString();
        }
        Debug.Log(highScore2.text);
        paused = true;
        pauseStuff.gameObject.SetActive(true);
        Time.timeScale = 0.0f;        
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
