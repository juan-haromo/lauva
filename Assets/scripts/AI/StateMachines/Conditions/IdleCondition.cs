using UnityEngine;

[CreateAssetMenu(fileName = "IdleCondition", menuName = "BaseEnemy/Conditions/IdleCondition")]
public class IdleCondition : BaseCondition
{
    public float maxIndexTime;
    public override bool Check(BaseStateMachine stateMachine, CallState stateType)
    {
        switch (stateType)
        {
            case CallState.waypoints:
                var temp = Vector3.Distance(stateMachine.gameObject.transform.position,
                    stateMachine.waypoints[stateMachine.curretWaypoint].position);
                if (temp < 1.5f)
                {
                    stateMachine.curretWaypoint++;
                    if (stateMachine.waypoints.Count <= stateMachine.curretWaypoint)
                    {
                        stateMachine.curretWaypoint = 0;
                    }
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