using UnityEngine;

[CreateAssetMenu(fileName = "StunState", menuName = "BaseEnemy/states/StunState")]
public class StunState : BaseState
{
    public override void EnterState(BaseStateMachine stateMachine)
    {
        StateType = CallState.stun;
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {

    }

    public override void ExitState(BaseStateMachine stateMachine)
    {

    }
}
