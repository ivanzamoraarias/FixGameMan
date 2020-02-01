using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int brokenAssetsInScene = 0;
    private int fixedAssets = 0;

    void Start()
    {
        fixedAssets = 0;
        FindBrokenAssets();
        GameEvents.AssetFixed += AssetsFixedCounter;
    }

    void FindBrokenAssets()
    {
        BrokenObject[] arr = FindObjectsOfType<BrokenObject>();
        brokenAssetsInScene = arr.Length;
    }

    void AssetsFixedCounter()
    {
        fixedAssets++;

        if(fixedAssets >= brokenAssetsInScene)
        {
            GameEvents.OnWinTriggered();
        }
    }
}
