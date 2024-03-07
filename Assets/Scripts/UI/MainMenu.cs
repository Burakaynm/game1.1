using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void GameSettings()
    {
        SceneManager.LoadScene("Settings Menu");
    }

    public void CharacterSelection()
    {
        SceneManager.LoadScene("Characters Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is closed");
    }

}
