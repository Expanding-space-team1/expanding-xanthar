using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PartManager.partAcquired += part => Debug.Log("Part acquired");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
