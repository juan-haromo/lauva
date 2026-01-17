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
                float distanceWandering = Vector3.Distance(stateMachine.gameObject.transform.position,stateMachine.blackboard.Get<Vector3>("stopPoint"));
                if (distanceWandering < 2)
                {
                    return true;
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