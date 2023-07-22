using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class MapController : MonoBehaviour
{
    [SerializeField] GameObject worldMap;
    [SerializeField] 
    bool isMapOpen = false;
    
    void Awake() 
    {
        worldMap.SetActive(false);
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
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
            worldMap.SetActive(true);
        }
        else
        {
            worldMap.SetActive(false);
        }
    }
}
