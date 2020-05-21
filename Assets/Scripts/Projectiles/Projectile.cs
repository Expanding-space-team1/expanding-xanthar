using System;
using PlayerData;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Projectile : MonoBehaviour
{

    // private Vector2 _targetPosition;

    [HideInInspector] public Vector2 _direction;

    [SerializeField] private float _maxTravelDistance;

    [SerializeField] private float speed;
    
    [HideInInspector]
    public float _damage;

    private Vector2 _startPosition;

    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _startPosition) >= _maxTravelDistance) Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce((Vector3)_direction * (Time.deltaTime * speed), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.otherCollider.gameObject.GetComponent<Player>() != null)
        {
            GameManager.GetInstance().Player.Damage(_damage);
        } else if (collision.otherCollider.gameObject.GetComponent<Enemy>() != null)
        {
            // TODO Damage Enemy
            
        }
        
        Destroy(gameObject);
        
        HitCollider(collision.GetContact(0).point);
    }
    
    private void HitCollider(Vector2 position)
    {
        EffectManager.GetInstance().Play(EffectManager.EffectType.EXPLOSION, position);
    }
}
