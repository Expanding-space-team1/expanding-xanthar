using UnityEngine;



public class Enemy : MonoBehaviour
{
    [Header("Base Stats")]
    public float _baseHealth;
    public float _baseDamage;
    
    [Header("Specific Stats")]
    public float _level;

    [HideInInspector]
    public float 
        _health,
        _damage;


    [SerializeField]
    private Goal[] _goals;
    
    [HideInInspector]
    public Goal _currentGoal;

    private bool hasGoals => _goals.Length > 0;

    private void Awake()
    {
        _health = _baseHealth * 0.02f * _level;
        _damage = _baseDamage * 0.03f * _level;
    }

    private void Start()
    {
        if (hasGoals)
        {
            SetGoal(_goals[0]);
        }
    }

    private void Update()
    {
        if (hasGoals)
        {
            if (_currentGoal.GoToNextGoal())
            {
                SetNextGoal(_currentGoal);
            }

            _currentGoal.OnActGoal();
        }
    }

    public void Damage(float damage)
    {
        if (damage <= 0) return;

        _health -= damage;

        if (_health < 0) _health = 0;

        if (_health > 0) return;

        Destroy(gameObject);
    }

    public void SetNextGoal(Goal currentGoal)
    {

        if (_goals.Length <= 1) return;

        var found = false;
        
        for (var i = 0; i < _goals.Length; i++)
        {
            var goal = _goals[i];
            
            if (found)
            {
                SetGoal(goal);
                break;
            }

            found = goal.GetType() == currentGoal.GetType();

            if (found && i == _goals.Length - 1)
            {

                SetGoal(_goals[0]);;
                break;
            }
        }
    }

    public void SetGoal(Goal goal)
    {
        if (goal == null) return;
        
        /** als we ons al in een state bevinden: geef de state de mogelijkheid zich op te ruimen */
        if(_currentGoal != null)
            _currentGoal.OnLeave();
        
        _currentGoal = goal;
        
        /** we geven de nieuwe state de mogelijkheid om zich zelf in te stellen */
        _currentGoal.OnEnter();
    }

    private void OnDestroy()
    {
        // TODO Play death effect
    }
}