using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public UnityEngine.UI.Text highScore;
    public GameObject tutorial_screen;
    public GameObject hide_canvas;
    public bool first_game;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("score", 0).ToString();
    }

    public void start_Tutorial()
    {
        if (first_game)
        {
            hide_canvas.SetActive(false);
            tutorial_screen.SetActive(true);
            first_game = false;
        }
        else
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("endless_scroll");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
