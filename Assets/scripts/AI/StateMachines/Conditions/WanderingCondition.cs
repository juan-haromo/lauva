using UnityEngine;

[CreateAssetMenu(fileName = "WanderingCondition", menuName = "BaseEnemy/Conditions/WanderingCondition")]
public class WanderingCondition : BaseCondition
{
    public float maxIndexTime = default;
    public override bool Check(BaseStateMachine stateMachine, CallState stateType)
    {
        switch (stateType)
        {
            case CallState.idle:
                if (stateMachine.blackboard.Get<float>("IdleIndexTime") != 0.0f)
                {
                    if (stateMachine.blackboard.Get<float>("IdleIndexTime") > maxIndexTime)
                    {
                        return true;
                    }
                }
                break;
            case CallState.walking:
                float distance = Vector3.Distance(stateMachine.gameObject.transform.position,
                    stateMachine.target.transform.position);
                if (distance > stateMachine.blackboard.Get<float>("maxPlayerDistance"))
                {
                    return true;
                }
                break;
            default:
                return false;
        }
        return false;
    }
}