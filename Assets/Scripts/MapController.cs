using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [SerializeField] GameObject worldMap;
    [SerializeField] GameObject miniMap;
    [SerializeField] 
    bool isMapOpen = false;
    
    void Awake() 
    {
        worldMap.SetActive(false);
        miniMap.SetActive(true);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            OpenCloseMap();
        }
    }

    void OpenCloseMap()
    {
        Debug.Log("action");
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
}
