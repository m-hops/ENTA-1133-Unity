using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreeMenu : MonoBehaviour
{
    public void ButtonMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void ButtonQuitGame()
    {
        Application.Quit();
    }
}
