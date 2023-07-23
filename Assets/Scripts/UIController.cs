using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro; 

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject worldMap;
    [SerializeField] GameObject miniMap;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Canvas mapCanvas;
    [SerializeField] TextMeshProUGUI checkpointsText;
    [SerializeField] GameObject keanuReevesButton;
    [SerializeField] GameObject normalJumpButton;
    [SerializeField] GameObject rickyBobbyButton;
    [SerializeField] GameObject normalMoveButton;

    //static UIController instance; this is for the singleton
    GameManager gameManager;
    bool isMapOpen = false;
    bool isPaused = false;
    float previousTimeScale;
    
    void Awake() 
    {
        //ManageSingleton();
        Time.timeScale = 1;
        worldMap.SetActive(false);
        pauseMenu.SetActive(false);
        miniMap.SetActive(true);
        //pauseMenu.SetActive(false);
    }

    /*void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }*/

    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        if (!isPaused)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                ToggleMap();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        checkpointsText.text = gameManager.GetRemainingCheckpoints().ToString();

        EnableFunButtons();
    }

    private void EnableFunButtons()
    {
        int remainingCheckpoints = gameManager.GetRemainingCheckpoints();
        if (remainingCheckpoints < 13)
        {
            rickyBobbyButton.SetActive(true);
            normalMoveButton.SetActive(true);
        }

        if (remainingCheckpoints < 7)
        {
            keanuReevesButton.SetActive(true);
            normalJumpButton.SetActive(true);
        }
    }

    void ToggleMap()
    {
        isMapOpen = !isMapOpen;
        if(isMapOpen)
        {
            miniMap.SetActive(false);
            worldMap.SetActive(true);
        }
        else
        {
            miniMap.SetActive(true);
            worldMap.SetActive(false);
        }
    }

    public void TogglePause()
    {
        if(Time.timeScale > 0)
        {
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            mapCanvas.enabled = false;

            isPaused = true;
        }

        else if(Time.timeScale == 0)
        {
            Time.timeScale = previousTimeScale;
            pauseMenu.SetActive(false);
            mapCanvas.enabled = true;

            isPaused = false;
        }
    }
}
