using UnityEngine;

[CreateAssetMenu(fileName = "WaypointMovement", menuName = "BaseEnemy/states/WaypointMovement")]
public class WaypointMovement : BaseState
{
    public override void EnterState(BaseStateMachine stateMachine)
    {
        StateType = CallState.waypoints;
        stateMachine.agent.isStopped = false;
    }
    public override void UpdateState(BaseStateMachine stateMachine)
    {
        stateMachine.agent.SetDestination(stateMachine.waypoints[stateMachine.curretWaypoint].position);
    }
    public override void ExitState(BaseStateMachine stateMachine)
    {

    }
}
