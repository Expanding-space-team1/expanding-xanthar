using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
   public int index;
   public Dialogue PartDialogue;

   public Dialogue _enemyDialogue;
  // public string levelName;
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      
      if (other.CompareTag("Player"))
      {
         if (FindObjectsOfType<PartPicker>().Length > 0)
         {
            FindObjectOfType<DialogueManager>().StartDialogue(PartDialogue);
            return;
         }
         
         if (FindObjectsOfType<Enemy>().Length > 0)
         {
            FindObjectOfType<DialogueManager>().StartDialogue(_enemyDialogue);
            return;
         }
         
         SceneManager.LoadScene(index);
         
         //SceneManager.LoadScene(levelName);
      }
   }
}
