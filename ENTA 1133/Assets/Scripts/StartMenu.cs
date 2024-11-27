using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject Default;
    public GameObject HowTo;

    public void ButtonPlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Monobius");
    }

    public void ButtonQuitGame()
    {
        Application.Quit();
    }

    public void ButtonHowTo()
    {
        Default.SetActive(false);
        HowTo.SetActive(true);
    }

    public void ButtonDefault()
    {
        Default.SetActive(true);
        HowTo.SetActive(false);
    }
}
