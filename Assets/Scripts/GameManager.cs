using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] UIController mapController;
    [SerializeField] List<GameObject> fogOfWarBlocks;
    [SerializeField] List<GameObject> scenicCheckpoints;
    int remainingCheckpoints;

    void Start()
    {
        remainingCheckpoints = scenicCheckpoints.Count;
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
                    remainingCheckpoints--;
                }
            }
        }
    }

    public int GetRemainingCheckpoints()
    {
        return remainingCheckpoints;
    }
}
