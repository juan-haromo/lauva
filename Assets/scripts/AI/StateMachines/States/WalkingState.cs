using UnityEngine;

[CreateAssetMenu(fileName = "WalkingState", menuName = "BaseEnemy/states/WalkingState")]
public class WalkingState : BaseState
{
    public override void EnterState(BaseStateMachine stateMachine)
    {
        StateType = CallState.walking;
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {

    }

    public override void ExitState(BaseStateMachine stateMachine)
    {

    }
}