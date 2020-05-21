
using UnityEngine;

public class IdleGoal : Goal
{

    [SerializeField] private float _idleTimeInSeconds;

    private float _currentIdleTimeInSeconds;

    // Wanneer er een nieuwe goal word geactiveerd
    public override void OnEnter()
    {
        _currentIdleTimeInSeconds = 0;
    }

    // Hier gaat de goal logica in, "Wat wil je doen?"
    public override void OnActGoal()
    {
        _currentIdleTimeInSeconds += Time.deltaTime;
    }

    // Hier ga ja om een bepaalde voorwaarde naar de volgende goal, "if (bla) nextGoal();"
    public override bool GoToNextGoal()
    {
        return _currentIdleTimeInSeconds > _idleTimeInSeconds;
    }
}