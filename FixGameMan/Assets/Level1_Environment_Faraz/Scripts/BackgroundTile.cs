using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTile : MonoBehaviour
{

    public bool isCreditScene;
    public GameObject go;

    // Start is called before the first frame update
    void Start()
    {
        if(isCreditScene)
        StartCoroutine("ActivateButton");
    }


    public IEnumerator ActivateButton()
    {
        yield return new WaitForSeconds(2.0f);
        go.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<SpriteRenderer>().material.mainTextureOffset += new Vector2(0.0f,0.1f * Time.deltaTime);
    }

    public void OnMouseDown()
    {
        if (!isCreditScene)
            Application.LoadLevel(1);
        else if(isCreditScene && go.activeInHierarchy)
            Application.LoadLevel(0);
    }
}
