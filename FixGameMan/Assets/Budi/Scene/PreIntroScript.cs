using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PreIntroScript : MonoBehaviour
{
    public UnityEvent TimerPlease;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.LooseTriggered += TimesUp;
        TimerPlease.Invoke();
    }

    void TimesUp()
    {
        SceneManager.LoadScene("IntroVideo");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
