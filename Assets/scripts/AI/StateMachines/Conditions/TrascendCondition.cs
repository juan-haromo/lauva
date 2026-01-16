using UnityEngine;

[CreateAssetMenu(fileName = "TrascendCondition", menuName = "BaseEnemy/Conditions/TrascendCondition")]
public class TrascendCondition : BaseCondition
{
    public override bool Check(BaseStateMachine stateMachine, CallState stateType)
    {
        if (stateMachine.blackboard.Get<bool>("trascend"))
        {
            return true;
        }
        return false;
    }
}