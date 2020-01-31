using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenObject : MonoBehaviour
{
    public GameObject canvasObj;
    public Sequence sequence;

    void Start()
    {
        canvasObj.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision enter");
        if(other.gameObject.tag == "Player")
        {
            canvasObj.SetActive(true);
            sequence.SetPlayer(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canvasObj.SetActive(false);
            sequence.ClearPlayer();
        }
    }
}
