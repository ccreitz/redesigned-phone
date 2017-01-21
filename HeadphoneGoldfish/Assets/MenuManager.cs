using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public UnityEngine.UI.Text highScore;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("score", 0).ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("endless_scroll");
    }
}
