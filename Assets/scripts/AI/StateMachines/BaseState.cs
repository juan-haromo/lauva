using UnityEngine;

public class BaseState : ScriptableObject
{
    public BaseCondition.Transition[] transitions;

    public virtual void EnterState(BaseStateMachine stateMachine)
    {
        
    }

    public virtual void ExitState(BaseStateMachine stateMachine)
    {
        
    }

    public virtual void UpdateState(BaseStateMachine stateMachine)
    {
        
    }
    
    public void CheckTransitions(BaseStateMachine stateMachine)
    {
        if (transitions.Length > 0)
        {
            foreach (BaseCondition.Transition t in transitions)
            {
                if (t.condition != null && t.condition.Check(stateMachine))
                {
                    stateMachine.ChangeState(t.state);
                    break;
                }
            }
        }
    }
}
