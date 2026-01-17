using UnityEngine;

[CreateAssetMenu(fileName = "waypoints", menuName = "BaseEnemy/Conditions/waypoints")]
public class waypoints : BaseCondition
{
    public float wayDis;
    public override bool Check(BaseStateMachine stateMachine, CallState stateType)
    {
        int temp = Random.Range(3, 10);
        if(temp < stateMachine.blackboard.Get<float>("IdleIndexTime"))
        {
            return true;
        }
        var tempdis = Vector3.Distance(stateMachine.transform.position, stateMachine.waypoints[stateMachine.curretWaypoint].transform.position);
        if(tempdis > wayDis)
        {
            return true;
        }
        return false;
    }
    
}
