using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "BaseEnemy/states/TrascendState")]
public class TrascendState : BaseState
{
    public override void EnterState(BaseStateMachine stateMachine)
    {
        StateType = CallState.tracend;
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {

    }

    public override void ExitState(BaseStateMachine stateMachine)
    {

    }
}
