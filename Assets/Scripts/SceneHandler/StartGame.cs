using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        Destroy (GameObject.FindWithTag("music"));
    }

    public void MenuStart()
    {
        
        SceneManager.LoadScene(1);
    }
}

