using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Sound;

public class SoundSwapper : MonoBehaviour
{
    bool isFixed = false;

    public string brokenSound;
    public string fixedSound;
    public int timeBetweenRepeat = 3;

    public bool isLastSound;

    public void StartLoop()
    {
        InvokeRepeating("PlaySound", 0, timeBetweenRepeat);
    }

    public void StopLoop()
    {
        CancelInvoke("PlaySound");
    }

    public void PlaySound()
    {
        if (isFixed)
        {
            AudioManager.instance.Play(fixedSound);
        }
        else
        {
            AudioManager.instance.Play(brokenSound);
        }
    }

    public void FixSound()
    {
        AudioManager.instance.Stop(brokenSound);
        isFixed = true;
        CancelInvoke("PlaySound");
        //AudioManager.instance.Play(fixedSound);
        if (isLastSound)
            AudioManager.instance.Play(fixedSound);
        else
            StartLoop();

    }
}
