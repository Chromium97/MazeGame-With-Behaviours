using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    //Manages the scene navigation for project

    //Loads HomeScreen scene
    public void GoHome()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    //Loads Settings scene
    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    //Loads Game scene
    public void GoToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    //Exits program
    public void ExitGame()
    {
        Application.Quit();
    }

    //Resets the characters score to zero
    public void ResetCharacter()
    {
        PlayerPrefs.SetFloat("TotalTime", 0);
        PlayerPrefs.SetInt("NumGames", 0);
        PlayerPrefs.SetFloat("HighScore", 0);
    }
}