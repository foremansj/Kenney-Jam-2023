using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] MapController mapController;
    [SerializeField] List<GameObject> fogOfWarBlocks;
    [SerializeField] List<GameObject> scenicCheckpoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableFogOfWar(GameObject checkpoint)
    {
        if(scenicCheckpoints.Contains(checkpoint))
        {
            for(int i = 0; i < fogOfWarBlocks.Count; i++)
            {
                if(checkpoint.ToString() == fogOfWarBlocks[i].ToString())
                {
                    fogOfWarBlocks[i].SetActive(false);
                }
            }
        }
    }
}
