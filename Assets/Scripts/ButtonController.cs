using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    string gameScene = "Port City";
    string howToPlayScene = "How To Play";
    string creditsScene = "Credits";

    string mainMenuScene = "Start Menu";
    Movement movement;
    UIController uIController;
    
    void Awake()
    {
        movement = FindObjectOfType<Movement>();
    }

    void Start()
    {
        uIController = GetComponent<UIController>();
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

    public void RickyBobby()
    {
        movement.ChangeMoveSpeed(true);
        uIController.TogglePause();
    }

    public void NormalSpeed()
    {
        movement.ChangeMoveSpeed(false);
        uIController.TogglePause();
    }

    public void KeanuReeves()
    {
        movement.ChangeJumpHeight(true);
        uIController.TogglePause();
    }

    public void NormalJump()
    {
        movement.ChangeJumpHeight(false);
        uIController.TogglePause();
    }
}
