using UnityEngine;

public class IdleCondition : BaseCondition
{
    public override bool Check(BaseStateMachine stateMachine)
    {
        return false;
    }
}