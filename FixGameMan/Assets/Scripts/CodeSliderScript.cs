using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodeSliderScript: MonoBehaviour
{
    public int[] sequence;
    public Text sequenceText;
    public Text inputText;
    Slider slider;

    private int currentIndex;

    Event test;

    void Start()
    {
        slider = GetComponent<Slider>();
        sequenceText.text = "";
        inputText.text = "";
        SetText();
        slider.maxValue = sequence.Length;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("0 Input");
            if(sequence[currentIndex] == 0)
            {
                AddToSlider();
                inputText.text += "0";
            }
            else
            {
                Reset();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("1 Input");
            if (sequence[currentIndex] == 1)
            {
                AddToSlider();
                inputText.text += "1";
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
        inputText.text = "";
    }

    void AddToSlider()
    {
        slider.value += slider.maxValue/sequence.Length;
        currentIndex++;

        if(slider.value == slider.maxValue)
        {
            Debug.Log("Sequence completed...");
        }

    }

    void SetText()
    {
        if (sequence.Length == 0)
        {
            Debug.Log("Array is empty...");
            return;
        }

        foreach(int i in sequence)
        {
            sequenceText.text += i.ToString() + " ";
        }
    }
}
