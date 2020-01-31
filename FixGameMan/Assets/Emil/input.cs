using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("0 Input");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("1 Input");
        }
    }
}
