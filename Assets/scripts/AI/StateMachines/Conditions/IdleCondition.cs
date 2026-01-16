using UnityEngine;

[CreateAssetMenu(fileName = "IdleCondition", menuName = "BaseEnemy/Conditions/IdleCondition")]
public class IdleCondition : BaseCondition
{
    public float maxIndexTime;
    public override bool Check(BaseStateMachine stateMachine, CallState stateType)
    {
        switch (stateType)
        {
            case CallState.wandering:
                if (stateMachine.blackboard.Get<float>("Wandering") != 0.0f)
                {
                    if (stateMachine.blackboard.Get<float>("Wandering") > maxIndexTime)
                    {
                        return true;
                    }
                }
                break;
            case CallState.walking:
                
                break;
            default:
                return false;
        }
        return false;
    }
}