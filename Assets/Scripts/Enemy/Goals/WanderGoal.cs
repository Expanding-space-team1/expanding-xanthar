using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WanderGoal : Goal
{
    
    [SerializeField]
    private float _arrivalDistance = 0f;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    private Vector2 _targetPosition;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnEnter()
    {
        ChooseTargetLocation();
    }
    
    public override void OnActGoal()
    {
        float step = _speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, step);
        if (_targetPosition.x > transform.position.x)
        {
            // Flip naar rechts
            if (_spriteRenderer.flipX)
            {
                _spriteRenderer.flipX = false;
            }
        }else if (_targetPosition.x < transform.position.x)
        {
            // Flip naar links
            if (!_spriteRenderer.flipX)
            {
                _spriteRenderer.flipX = true;
            }
        }
        
    }

    public override bool GoToNextGoal()
    {
        return Vector2.Distance(transform.position, _targetPosition) < _arrivalDistance;
    }
    
    void ChooseTargetLocation(){
        // kiest een locatie binnen het veld van de camera
        Vector3 world = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        _targetPosition.x = Random.Range(-world.x, world.x);
        _targetPosition.y = Random.Range(-world.y, world.y);
    }
}