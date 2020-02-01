using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Sound;

public class gravityFix : MonoBehaviour
{
    private GameObject[] myJellies;
    // Start is called before the first frame update
    void Start()
    {
        myJellies = GameObject.FindGameObjectsWithTag("car");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (GameObject car in myJellies)
        {
            car.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        AudioManager.instance.Play("collect");

        Destroy(gameObject);
    }
}
