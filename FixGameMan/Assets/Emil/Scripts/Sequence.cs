using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Sequence : MonoBehaviour
{
    public int[] sequenceArr;
    public Text sequenceText;
    Slider slider;
    public UnityEvent onComplete;
    private int currentIndex;
    private GameObject player;

    void Start()
    {
        slider = GetComponent<Slider>();
        sequenceText.text = "";
        SetText();
        slider.maxValue = sequenceArr.Length;
    }

    void Update()
    {
        if (player == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("0 Input");
            if(sequenceArr[currentIndex] == 0)
            {
                AddToSlider();
            }
            else
            {
                Reset();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("1 Input");
            if (sequenceArr[currentIndex] == 1)
            {
                AddToSlider();
            }
            else
            {
                Reset();
            }
        }
    }

    void Reset()
    {
        slider.value = 0;
        currentIndex = 0;
    }

    void AddToSlider()
    {
        slider.value += slider.maxValue/sequenceArr.Length;
        currentIndex++;

        if(slider.value == slider.maxValue)
        {
            Debug.Log("Sequence completed...");
            onComplete.Invoke();
            //
        }

    }

    void SetText()
    {
        if (sequenceArr.Length == 0)
        {
            Debug.Log("Array is empty...");
            return;
        }

        foreach(int i in sequenceArr)
        {
            sequenceText.text += i.ToString() + " ";
        }
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    public void ClearPlayer()
    {
        this.player = null;
    }
}
