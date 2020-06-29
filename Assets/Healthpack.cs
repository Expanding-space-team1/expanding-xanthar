using System;
using System.Collections;
using System.Collections.Generic;
using PlayerData;
using UnityEngine;

public class Healthpack : MonoBehaviour
{
 private Player _playerHealth;

 public float healthBonus = 50f;
 public GameObject HP;

 void Awake()
 {
  _playerHealth = FindObjectOfType<Player>();
 }

 private void OnTriggerEnter2D(Collider2D other)
 {
  if (other.CompareTag("Player"))
  {
   if (_playerHealth._health < _playerHealth._maxHealth)
   {
    Destroy(gameObject);
    _playerHealth._health = _playerHealth._health + healthBonus;

    //instantiate +50hp particle
    GameObject hp = Instantiate(HP) as GameObject;
    hp.transform.position = transform.position;


    if (_playerHealth._health > _playerHealth._maxHealth) //niet meer dan max health
    {
     _playerHealth._health = _playerHealth._maxHealth;
    }
    }
   }
  }
 }


