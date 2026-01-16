using UnityEngine;

[CreateAssetMenu(fileName = "StunCondition", menuName = "BaseEnemy/Conditions/StunCondition")]
public class StunCondition : BaseCondition
{
    public float maxStunTime;
    public override bool Check(BaseStateMachine stateMachine, CallState stateType)
    {
        if (maxStunTime < stateMachine.blackboard.Get<float>("StunTime"))
        {
            return true;
        }
        return false;
    }
}