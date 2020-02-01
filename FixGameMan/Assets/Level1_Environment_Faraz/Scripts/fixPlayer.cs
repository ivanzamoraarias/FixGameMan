using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Sound;

public class fixPlayer : MonoBehaviour
{

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
        other.GetComponent<player2D>().isPlayerFixed = true;
        other.GetComponent<player2D>().Jump();
        other.GetComponent<Animator>().SetBool("isFixed", true);
        other.GetComponent<AudioSource>().Pause();
        other.GetComponent<AudioSource>().Stop();


        AudioManager.instance.Play("collect");

        other.GetComponent<player2D>().FixPlayerMovement();
        Destroy(gameObject);
    }
}
