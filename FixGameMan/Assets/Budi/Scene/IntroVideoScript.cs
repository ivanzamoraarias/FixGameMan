using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroVideoScript : MonoBehaviour
{
    public Text skipText;
    public VideoPlayer vp;

    private float timer = 0f;
    public static float timerMax = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        vp.loopPointReached += VideoDone;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            timer += Time.deltaTime;
            if (timer >= timerMax)
            {
                //skip to tutorial
                if (vp.time < 76)
                {
                    vp.time = 76;
                    timer = 0f;
                }
                else
                { //or skip to next scene
                    VideoDone(vp);
                }
            }
        }
        else
        {
            timer -= Time.deltaTime*2;
            if (timer < 0f) timer = 0f;
        }

        skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, timer <= 0.1f ? 0.1f : ((timer+1) / (timerMax+1)));
    }

    void VideoDone(VideoPlayer vp)
    {
        SceneManager.LoadScene("Gameplay_Level1_Completed");
    }

}
