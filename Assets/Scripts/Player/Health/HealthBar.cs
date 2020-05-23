using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerData
{ 
    public class HealthBar : MonoBehaviour
{

    private Slider _slider;
    private Image _fillImage;
    private Player _player;


    //public Gradient gradient;

    void Awake()
    {
        _player = FindObjectOfType<Player>();
        _slider = GetComponent<Slider>();
        foreach (var componentsInChild in _slider.GetComponentsInChildren<Image>())
        {
            if(componentsInChild.gameObject.name != "Fill") continue;
            _fillImage = componentsInChild;
            break;
        }

        GameManager.PlayerDamage += UpdateSlider;
    }
    public void UpdateSlider()
    {
        if(_slider == null) return;

        _slider.value = GameManager.GetInstance().Player._health / GameManager.GetInstance().Player._maxHealth;

        if (_slider.value == 0)
        {
            _fillImage.gameObject.SetActive(false);
        }
    }
  }
}
