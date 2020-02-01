using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingAnimation : MonoBehaviour
{
    public GameObject Building;
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
        Animator animatorObjet = Building.GetComponent<Animator>();
        animatorObjet.SetBool("isFixed", true);
    }
}
