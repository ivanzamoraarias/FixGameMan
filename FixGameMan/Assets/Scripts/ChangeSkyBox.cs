using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Sound;

public class ChangeSkyBox : MonoBehaviour
{
    public Material newSky;
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
        if (other.gameObject.tag == "Player")
        {
            AudioManager.instance.Play("collect");

            RenderSettings.skybox = newSky;

            GameEvents.OnAssetFixed();

            Destroy(gameObject);
        }
    }
}