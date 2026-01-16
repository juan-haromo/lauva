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
                if (stateMachine.blackboard.Get<float>("WanderingIndexTime") != 0.0f)
                {
                    if (stateMachine.blackboard.Get<float>("WanderingIndexTime") > maxIndexTime)
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