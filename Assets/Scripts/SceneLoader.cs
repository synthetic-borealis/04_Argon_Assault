using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Invoke("LoadFirstLevel", 3f);
    }

    void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
