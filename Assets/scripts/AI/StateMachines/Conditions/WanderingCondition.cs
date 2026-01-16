using UnityEngine;

[CreateAssetMenu(fileName = "WanderingCondition", menuName = "BaseEnemy/Conditions/WanderingCondition")]
public class WanderingCondition : BaseCondition
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