using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildRocket : MonoBehaviour
{
    private bool inTrigger;
    public Dialogue dialogue;

    private void Update()
    {
        if(!inTrigger) return;
        if (Input.GetButtonDown("Interact"))
        {
            if (PartManager.GetInstance().HasAllParts())
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        inTrigger = false;
    }
}
