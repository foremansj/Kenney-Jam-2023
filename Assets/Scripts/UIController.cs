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
        if(!isPaused)
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                ToggleMap();
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }

        checkpointsText.text = gameManager.GetRemainingCheckpoints().ToString();
    }

    void ToggleMap()
    {
        //Debug.Log("action");
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

    /*void Pause()
    {
        Debug.Log("pausing");
        pauseMenu.SetActive(true);
        mapCanvas.enabled = false;
        Time.timeScale = 0;

        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        mapCanvas.enabled = true;
        isPaused = false;
        Time.timeScale = 1;

        
    }*/

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
