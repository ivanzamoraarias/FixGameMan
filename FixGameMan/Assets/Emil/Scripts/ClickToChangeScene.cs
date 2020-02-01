using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToChangeScene : MonoBehaviour
{
    public string sceneToLoad;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
