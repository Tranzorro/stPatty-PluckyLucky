using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuOptions : MonoBehaviour {

	public void BeginGame()
    {
        // load main level scene here
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        // quit app here
        Application.Quit();
    }

    public void MainMenu()
    {
        //load main menu here
        SceneManager.LoadScene(0);
    }
}
