using UnityEngine;

[CreateAssetMenu(fileName = "FollowingCondition", menuName = "BaseEnemy/Conditions/FollowingCondition")]
public class FollowingCondition : BaseCondition
{
    public override bool Check(BaseStateMachine stateMachine, CallState stateType)
    {
        switch (stateType)
        {
            default:
                return false;
        }
        return false;
    }
}