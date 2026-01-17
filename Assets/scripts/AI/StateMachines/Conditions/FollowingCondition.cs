using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "FollowingCondition", menuName = "BaseEnemy/Conditions/FollowingCondition")]
public class FollowingCondition : BaseCondition
{
    public override bool Check(BaseStateMachine stateMachine, CallState stateType)
    {
        float distance = Vector3.Distance(stateMachine.gameObject.transform.position, stateMachine.target.position);
        if (distance < stateMachine.blackboard.Get<float>("maxPlayerDistance"))
        {
            return true;
        }
        return false;
    }
}