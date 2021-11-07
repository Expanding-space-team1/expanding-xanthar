using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PassThrough : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool wallTrigger;
    void OnTriggerEnter2D (Collider2D other)
    {
        wallTrigger = false;
    }
 
    void OnTriggerExit2D (Collider2D other)
    {
        wallTrigger = true;
 
        var magnitude = 2500;
 
        var force = transform.position - other.transform.position;
 
        force.Normalize ();
        GetComponent<Rigidbody2D> ().AddForce (-force * magnitude);
 
 
    }
    // //private void OnCollisionEnter2D(Collision2D col)
    // {
    //     //Debug.Log("Collision");
    //     //if (col.gameObject.CompareTag("Collision"))
    //     //{
    //         //Debug.Log("TAG");
    //         //GetComponent<BoxCollider2D>().isTrigger = true;
    //         //GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
    //         //new WaitForSeconds(0.5f);
    //         
    //     //}
    //     
    // }
}
