﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAnimation : MonoBehaviour
{
    public GameObject Building;
    private GameObject[] Buildings;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ANIMATION BUILDING");
        Animator animatorObjet = Building.GetComponent<Animator>();
        animatorObjet.SetBool("isFixed", true);

        foreach (GameObject building in Buildings)
        {
            Animator buildingAnimator = building.GetComponent<Animator>();
            buildingAnimator.SetBool("isFixed", true);
        }

    }
}
