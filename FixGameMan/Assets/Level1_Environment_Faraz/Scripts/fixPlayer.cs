using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Destroy(gameObject);
    }
}
