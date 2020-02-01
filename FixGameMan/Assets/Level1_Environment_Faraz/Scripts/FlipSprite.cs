using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void FlipTheSprite()
    {
        Debug.Log("asd");
        this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
    }
}
