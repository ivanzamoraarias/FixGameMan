using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Sound;

public class GameManager : MonoBehaviour
{
    private int brokenAssetsInScene = 0;
    private int fixedAssets = 0;

    void Start()
    {
        fixedAssets = 0;
        FindBrokenAssets();
        GameEvents.AssetFixed += AssetsFixedCounter;
        AudioManager.instance.Play("bgm1");
    }

    void FindBrokenAssets()
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("item");
        BrokenObject[] arr = FindObjectsOfType<BrokenObject>();
        brokenAssetsInScene = arr.Length + items.Length;
        Debug.Log(brokenAssetsInScene + " broken assets in scene...");
    }

    void AssetsFixedCounter()
    {
        fixedAssets++;

        if(fixedAssets >= brokenAssetsInScene)
        {
            GameEvents.OnWinTriggered();
        }
    }

    void OnDestroy()
    {
        GameEvents.AssetFixed -= AssetsFixedCounter;
    }
}
