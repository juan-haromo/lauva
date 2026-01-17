using UnityEngine;

[CreateAssetMenu(fileName = "TrascendState", menuName = "BaseEnemy/states/TrascendState")]
public class TrascendState : BaseState
{
    public override void EnterState(BaseStateMachine stateMachine)
    {
        StateType = CallState.tracend;
        Destroy(stateMachine.gameObject);
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {
        
    }

    public override void ExitState(BaseStateMachine stateMachine)
    {

    }
}
