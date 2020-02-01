using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int brokenAssetsInScene = 0;
    private int fixedAssets = 0;

    void Start()
    {
        Debug.Log("HAHAHA");
        fixedAssets = 0;
        FindBrokenAssets();
        GameEvents.AssetFixed += AssetsFixedCounter;
    }

    void FindBrokenAssets()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("item");
        BrokenObject[] arr = FindObjectsOfType<BrokenObject>();
        brokenAssetsInScene = arr.Length + items.Length;
        Debug.Log("HIH");
        Debug.Log(brokenAssetsInScene);
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
