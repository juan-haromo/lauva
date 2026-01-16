using UnityEngine;

[CreateAssetMenu(fileName = "WanderingState", menuName = "BaseEnemy/states/WanderingState")]
public class WanderingState : BaseState
{
    
    public override void EnterState(BaseStateMachine stateMachine)
    {
        StateType = CallState.wandering;
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {
        Debug.Log("asdfasdf");
    }

    public override void ExitState(BaseStateMachine stateMachine)
    {

    }
}
