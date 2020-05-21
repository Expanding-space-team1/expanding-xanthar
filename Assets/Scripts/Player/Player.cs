using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlayerData
{
    public class Player : MonoBehaviour
{
        public float _maxHealth;
        [HideInInspector]
        public float _health;

        public float _damage;
    
        // Start is called before the first frame update
        void Start()
        {
            _health = _maxHealth;
        }

        public void Damage(float damage)
        {
            _health -= damage;

            if (_health < 0) _health = 0;
        
            GameManager.PlayerDamage?.Invoke();

            if (_health > 0) return;

            GameManager.PlayerDeath?.Invoke();
        }
    }

}