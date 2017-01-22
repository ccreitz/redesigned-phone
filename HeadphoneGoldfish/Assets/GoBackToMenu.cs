using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMenu : MonoBehaviour {
    public void GoMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
    public void GoAgain()
    {
        SceneManager.LoadScene("endless_scroll");
    }
}
