using UnityEngine;

[CreateAssetMenu(fileName = "StunCondition", menuName = "BaseEnemy/Conditions/StunCondition")]
public class StunCondition : BaseCondition
{
    public override bool Check(BaseStateMachine stateMachine, CallState stateType)
    {
        switch (stateType)
        {
            default:
                return false;
        }
    }
}