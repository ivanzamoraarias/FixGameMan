using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Sound;

public class BuildingAnimation : MonoBehaviour
{
    public GameObject Building;
    private GameObject[] Buildings;
    // Start is called before the first frame update
    void Start()
    {
        Buildings = GameObject.FindGameObjectsWithTag("building");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ANIMATION BUILDING");
        

        foreach (GameObject b in Buildings)
        {
            Animator animatorObjet = b.GetComponent<Animator>();
            animatorObjet.SetBool("isFixed", true);
        }
        AudioManager.instance.Play("collect");
        GameEvents.OnAssetFixed();

        Destroy(gameObject);

    }
}
