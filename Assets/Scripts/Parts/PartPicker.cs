using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartPicker : MonoBehaviour
{
    public Part _part;
    private bool inTrigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_part == null) return;
        if(other.gameObject.tag != "Player") return;
        inTrigger = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (_part == null) return;
        if(other.gameObject.tag != "Player") return;
        inTrigger = false;
    }
    
    private void Update()
    {
        if (!inTrigger) return;
        
        if (Input.GetButtonDown("Interact"))
        {
            PartManager.GetInstance().AddPart(_part);
        }
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _part._sprite;
    }
}
