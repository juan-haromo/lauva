using UnityEngine;

[CreateAssetMenu(fileName = "StunState", menuName = "BaseEnemy/states/StunState")]
public class StunState : BaseState
{
    public override void EnterState(BaseStateMachine stateMachine)
    {
        StateType = CallState.stun;
        stateMachine.blackboard.Set("StunIndexTime", 0f);
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {
        var temp = stateMachine.blackboard.Get<float>("StunIndexTime") + Time.deltaTime;
        stateMachine.blackboard.Set("StunIndexTime", temp);
    }

    public override void ExitState(BaseStateMachine stateMachine)
    {

    }
}
