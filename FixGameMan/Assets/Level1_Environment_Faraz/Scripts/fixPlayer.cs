using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Sound;




using UnityEngine.Events;

public class fixPlayer : MonoBehaviour
{
    public UnityEvent onCollect;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
       // other.GetComponent<player2D>().isPlayerFixed = true;
        //other.GetComponent<player2D>().Jump();
        //other.GetComponent<Animator>().SetBool("isFixed", true);
        //other.GetComponent<AudioSource>().Pause();
        //other.GetComponent<AudioSource>().Stop();


        AudioManager.instance.Play("collect");

        other.GetComponent<player2D>().FixPlayerMovement();
        onCollect.Invoke();
        Destroy(gameObject);
    }
}
