using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "BaseEnemy/states/WanderingState")]
public class WanderingState : BaseState
{
    
    public override void EnterState(BaseStateMachine stateMachine)
    {
        StateType = CallState.wandering;
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {

    }

    public override void ExitState(BaseStateMachine stateMachine)
    {

    }
}
