using UnityEngine;

public class BaseState : ScriptableObject
{
    public BaseCondition.Transition[] transitions;
    public CallState StateType;
    
    public virtual void EnterState(BaseStateMachine stateMachine)
    {
        
    }

    public virtual void ExitState(BaseStateMachine stateMachine)
    {
        
    }

    public virtual void UpdateState(BaseStateMachine stateMachine)
    {
        
    }
    
    public void CheckTransitions(BaseStateMachine stateMachine, CallState stateType)
    {
        if (transitions.Length > 0)
        {
            foreach (BaseCondition.Transition t in transitions)
            {
                if (t.condition != null && t.condition.Check(stateMachine, stateType))
                {
                    stateMachine.ChangeState(t.state);
                    break;
                }
            }
        }
    }
}
public enum CallState
{
    idle,
    waypoints,
    walking,
    stun,
    tracend,
}