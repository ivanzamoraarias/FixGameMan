using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGJ.Sound;
public class MaterialManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Material originalMat;
    public Material glitcgMat;
    
    void Start()
    {
      
    }

    public void FixGlitchMaterial()
    {
        this.GetComponent<SpriteRenderer>().material = originalMat;
        this.transform.position = new Vector3(this.transform.position.x,this.transform.position.y,0f);
        AudioManager.instance.Play("collect");
    }

    //public void OnMouseDown()
    //{
    //    FixGlitchMaterial();
    //}
    // Update is called once per frame
    
}
