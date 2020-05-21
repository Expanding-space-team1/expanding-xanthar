
using UnityEngine;

public class ShootProjectileGoal : Goal
{

    [SerializeField] private Projectile _projectilePrefab;

    private bool shot;

    public override void OnEnter()
    {
        shot = false;
    }

    public override void OnActGoal()
    {
        
        
        shot = true;

        if (_projectilePrefab == null)
        {
            Debug.LogWarning("No enemy projectile");
            
            return;
        }

        var position = transform.position;
        var projectileObject = Instantiate(_projectilePrefab.gameObject, position, Quaternion.identity);
        
        var projectile = projectileObject.GetComponent<Projectile>();
            
        projectile._damage = GetComponent<Enemy>()._damage;



        projectile._direction = GetDirectionToPlayer();
    }

    public override bool GoToNextGoal()
    {
        return shot;
    }

    private Vector2 GetDirectionToPlayer()
    {
        return (Vector2) GameManager.GetInstance()._playerObject.transform.position - (Vector2) transform.position;
    }
}