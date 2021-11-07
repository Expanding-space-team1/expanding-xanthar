using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Music;
    private void Awake()
    {
        DontDestroyOnLoad(Music);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
