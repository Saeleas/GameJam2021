using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public LevelLoader loader;
    public void Play()
    {
        loader.LoadNextLevel();
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("05_Credits");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
