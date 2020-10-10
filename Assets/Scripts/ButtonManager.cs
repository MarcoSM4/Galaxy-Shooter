using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()

    {
        Application.Quit();
    }
}