﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Text text;
    public Text clickText;
    public Image background;

    void Start()
    {
        text.gameObject.SetActive(false);
        clickText.gameObject.SetActive(false);
        background.gameObject.SetActive(false);

        GameEvents.WinTriggered += ShowWin;
    }

    void ShowWin()
    {
        text.gameObject.SetActive(true);
        clickText.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
    }
}
