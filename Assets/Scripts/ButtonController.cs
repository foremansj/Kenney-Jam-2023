using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    string gameScene = "Test Environment 1";
    string howToPlayScene = "How To Play";
    string creditsScene = "Credits";

    string mainMenuScene = "Start Menu";
    
    void Awake()
    {

    }
    public void StartGameButton()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void HowToPlayButton()
    {
        SceneManager.LoadScene(howToPlayScene);
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene(creditsScene);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void OpenURL(string link)
    {
        Application.OpenURL(link);
    }

    public void RespawnButton()
    {
        
    }
}
