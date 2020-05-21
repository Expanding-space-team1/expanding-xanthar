using UnityEngine;

public abstract class Goal : MonoBehaviour
{
    public virtual void OnEnter()
    {
    }

    public virtual void OnLeave()
    {
    }

    public abstract void OnActGoal();

    public abstract bool GoToNextGoal();
}