using UnityEngine;

public class WanderGoal : Goal
{
    
    [SerializeField]
    private float _arrivalDistance = 0f;

    [SerializeField]
    private float _speed;

    private Vector2 _targetPosition;
    
    public override void OnEnter()
    {
        ChooseTargetLocation();
    }
    
    public override void OnActGoal()
    {
        float step = _speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, step);
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