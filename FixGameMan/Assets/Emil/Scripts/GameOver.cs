using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text text;
    public Text clickText;
    public Image background;

    void Start()
    {
        text.gameObject.SetActive(false);
        clickText.gameObject.SetActive(false);
        background.gameObject.SetActive(false);

        GameEvents.LooseTriggered += ShowGameOver;
    }

    void ShowGameOver()
    {
        text.gameObject.SetActive(true);
        clickText.gameObject.SetActive(true);
        background.gameObject.SetActive(true);
    }
}
