using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float DestroyTime = 1.0f;
    void Start()
    {
        Object.Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


