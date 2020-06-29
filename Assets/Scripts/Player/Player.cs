using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace PlayerData
{
    public class Player : MonoBehaviour
    {

        public float _maxHealth;
        //[HideInInspector]
        public float _health;

        public float _damage;

        public GameObject _particle;
        
    
        // Start is called before the first frame update
        void Start()
        {
            _health = _maxHealth;
            GameManager.PlayerDeath += HandlePlayerDeath;
            
        }

        public void Damage(float damage)
        {
            _health -= damage;
            
            //insantiate -10hp
            GameObject hp = Instantiate(_particle) as GameObject;
            hp.transform.position = transform.position;
            //---
            if (_health < 0) _health = 0;
        
            GameManager.PlayerDamage?.Invoke();

            if (_health > 0) return;

            GameManager.PlayerDeath?.Invoke();
            new WaitForSeconds(0.5f);
            

        }
        private void HandlePlayerDeath()
        {
            EffectManager.GetInstance().Play(EffectManager.EffectType.PLAYER_DEATH, transform.position);
            gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .0f);
            SceneManager.LoadScene(10);
        }
    }
    

}