using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text secondsText;
    public int timeToBeatLevel = 30;

    float timer = 0f;
    bool isCounting = false;   
    
    void Start()
    {
        ResetTimer();
        StartTimer();
    }

    void Update()
    {
        if(isCounting) timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            StopTimer();
            GameEvents.OnLooseTriggered();
        }
        secondsText.text = ((int)timer).ToString();
    }

    public void StartTimer()
    {
        isCounting = true;
    }

    public void StopTimer()
    {
        isCounting = false;
    }

    public void ResetTimer()
    {
        timer = (float)timeToBeatLevel;
    }
}
