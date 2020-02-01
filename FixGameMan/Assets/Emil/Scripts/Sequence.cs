using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using GGJ.Sound;

public class Sequence : MonoBehaviour
{
    public int sequenceLength;
    public Text sequenceText;
    Slider slider;
    public UnityEvent onComplete;

    private List<int> sequenceList = new List<int>();
    private int currentIndex;
    private GameObject player;
    private bool isFixed = false;

    public Image imageFill;

    void Start()
    {
        AddSequence();
        slider = GetComponent<Slider>();
        sequenceText.text = "";
        SetText();
        slider.maxValue = sequenceList.Count;
    }

    void Update()
    {
        if (player == null || isFixed) return;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("0 Input");
            if(sequenceList[currentIndex] == 0)
            {
                AddToSlider();
                AudioManager.instance.Play("hit12");
            }
            else
            {
                Reset();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("1 Input");
            if (sequenceList[currentIndex] == 1)
            {
                AddToSlider();
                AudioManager.instance.Play("hit17");
            }
            else
            {
                Reset();
            }
        }
    }

    void AddSequence()
    {
        for(int i = 0; i < sequenceLength; i++)
        {
            sequenceList.Add(Random.Range(0, 2));
        }
    }

    void Reset()
    {
        slider.value = 0;
        currentIndex = 0;
    }

    void AddToSlider()
    {
        slider.value += slider.maxValue/(sequenceList.Count);
        currentIndex++;
        imageFill.fillAmount = slider.value/3.0f;

        if(slider.value == slider.maxValue)
        {
            Debug.Log("Sequence completed...");
            onComplete.Invoke();
            isFixed = true;
            GameEvents.OnAssetFixed();
        }

    }

    void SetText()
    {
        if (sequenceList.Count == 0)
        {
            Debug.Log("List is empty...");
            return;
        }

        foreach(int i in sequenceList)
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
