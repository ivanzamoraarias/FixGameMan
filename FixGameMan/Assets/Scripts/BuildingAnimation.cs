using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Sound;

public class BuildingAnimation : MonoBehaviour
{
    public string type;
    private GameObject[] Buildings;
    // Start is called before the first frame update
    void Start()
    {
        if(type == "building")
            Buildings = GameObject.FindGameObjectsWithTag("building");
        else if(type == "glitch")
            Buildings = GameObject.FindGameObjectsWithTag("glitch");
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
            if(animatorObjet != null)
            animatorObjet.SetBool("isFixed", true);
        }
        AudioManager.instance.Play("collect");
        GameEvents.OnAssetFixed();

        AudioManager.instance.Play("building");

        Destroy(gameObject);

    }
}
