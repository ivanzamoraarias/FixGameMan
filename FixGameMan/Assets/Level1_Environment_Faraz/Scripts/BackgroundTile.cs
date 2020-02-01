using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<SpriteRenderer>().material.mainTextureOffset += new Vector2(0.0f,0.1f * Time.deltaTime);
    }

    public void OnMouseDown()
    {
        Application.LoadLevel(1);
    }
}
