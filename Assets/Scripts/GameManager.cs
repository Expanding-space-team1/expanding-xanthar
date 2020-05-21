using System;
using PlayerData;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;

    public static GameManager GetInstance()
    {
        return Instance;
    }
    
    public GameObject _playerObject;
    
    public Player Player => _playerObject.GetComponent<Player>();
    
    public static Action PlayerDeath;
    public static Action PlayerDamage;
    
    void Awake()
    {
        Instance = this;
        if (_playerObject == null) _playerObject = GameObject.FindWithTag("Player");
        Debug.Log(_playerObject);
        
        EnemyHandler.SetInstance(new EnemyHandler());
    }
    
    void OnEnable()
    {
        Instance = this;
    }
}
