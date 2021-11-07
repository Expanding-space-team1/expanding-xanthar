using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Pathfinding;

public class WanderGoal : Goal
{
    public Animator myAnim;
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

        MoveToGoal(step);
        if (_targetPosition.x > transform.position.x)
        {

        // {
        //     // Flip naar rechts
        //     if (_spriteRenderer.flipX)
        //     {
        //         _spriteRenderer.flipX = false;
        //     }
        // }else if (_targetPosition.x < transform.position.x)
        // {
        //     // Flip naar links
        //     if (!_spriteRenderer.flipX)
        //     {
        //         _spriteRenderer.flipX = true;
        //     }
        }
        
    }
    
     private void MoveToGoal(float step)
    {
        myAnim.SetFloat("IsMoving", 1 );
        Debug.Log(myAnim.GetFloat("IsMoving"));
        myAnim.SetFloat("MoveX",(_targetPosition.x - transform.position.x));
        myAnim.SetFloat("MoveX",(_targetPosition.y - transform.position.y));
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, step);
    }

    public override bool GoToNextGoal()
    {
        myAnim.SetFloat("IsMoving", 0 );
        return Vector2.Distance(transform.position, _targetPosition) < _arrivalDistance;
        
        
    }
    
    void ChooseTargetLocation(){
        // kiest een locatie binnen het veld van de camera
        Vector3 world = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        _targetPosition.x = Random.Range(-world.x, world.x);
        _targetPosition.y = Random.Range(-world.y, world.y);
    }
}