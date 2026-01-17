using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "WanderingState", menuName = "BaseEnemy/states/WanderingState")]
public class WanderingState : BaseState
{
    public float searchRange;
    public float stopSlope;
    public override void EnterState(BaseStateMachine stateMachine)
    {
        stateMachine.blackboard.Set("WanderingIndexTime", 0f);
        stateMachine.agent.isStopped = false;
        var temp = GetRandomPointOnNavMesh(stateMachine);
        stateMachine.blackboard.Set("stopPoint", temp);
        StateType = CallState.wandering;
        stateMachine.agent.SetDestination(stateMachine.blackboard.Get<Vector3>("stopPoint"));
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {
    }

    public override void ExitState(BaseStateMachine stateMachine)
    {
        stateMachine.agent.isStopped = true;
        stateMachine.blackboard.Set("stopPoint",stateMachine.transform.position);
    }
    Vector3 GetRandomPointOnNavMesh(BaseStateMachine stateMachine)
    {
        Vector3 randomDirection = Random.insideUnitCircle * searchRange;
        Vector3 targetPosition = stateMachine.transform.position + new Vector3(randomDirection.x, randomDirection.y, 0);
        
        NavMeshHit hit;
        int walkableAreaIndex = NavMesh.GetAreaFromName("Walkable");
        Debug.Log(walkableAreaIndex);
        if (NavMesh.SamplePosition(targetPosition, out hit, 10.0f, walkableAreaIndex))
        {
            return hit.position;
        }
        else
        {
            Debug.Log("help");
            return stateMachine.gameObject.transform.position;
        }
    }

}
