using UnityEngine;

[CreateAssetMenu(fileName = "waypoints", menuName = "BaseEnemy/Conditions/waypoints")]
public class waypoints : BaseCondition
{
    public override bool Check(BaseStateMachine stateMachine, CallState stateType)
    {
        int temp = Random.Range(3, 10);
        if(temp < stateMachine.blackboard.Get<float>("IdleIndexTime"))
        {
            return true;
        }
        return false;
    }
    
}
