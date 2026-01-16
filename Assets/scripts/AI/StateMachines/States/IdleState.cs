using System;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "BaseEnemy/states/IdleState")]
public class IdleState : BaseState
{
    public override void EnterState(BaseStateMachine stateMachine)
    {
        stateMachine.blackboard.Set("IdleIndexTime", 0f);
        StateType = CallState.idle;
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {
        stateMachine.gameObject.transform.Rotate(0,0,5f);
        var temp = stateMachine.blackboard.Get<float>("IdleIndexTime") + Time.deltaTime;
        stateMachine.blackboard.Set("IdleIndexTime", temp);
    }

    public override void ExitState(BaseStateMachine stateMachine)
    {
        stateMachine.blackboard.Set("IdleIndexTime", 0f);
        stateMachine.transform.rotation = new Quaternion(0, 0, 0,0);
    }
}
