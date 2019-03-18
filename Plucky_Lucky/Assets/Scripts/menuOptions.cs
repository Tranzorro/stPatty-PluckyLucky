using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuOptions : MonoBehaviour {
    public Canvas credits;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    public void BeginGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void CreditsButton()
    {
        credits.enabled = true;
    }

    public void BackButton()
    {
        credits.enabled = false;
    }
}
