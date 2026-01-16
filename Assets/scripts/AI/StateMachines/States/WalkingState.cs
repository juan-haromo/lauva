using UnityEngine;

[CreateAssetMenu(fileName = "WalkingState", menuName = "BaseEnemy/states/WalkingState")]
public class WalkingState : BaseState
{
    public override void EnterState(BaseStateMachine stateMachine)
    {
        StateType = CallState.walking;
        stateMachine.agent.isStopped = false;
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {
        stateMachine.agent.SetDestination(stateMachine.target.position);
    }

    public override void ExitState(BaseStateMachine stateMachine)
    {

    }
}