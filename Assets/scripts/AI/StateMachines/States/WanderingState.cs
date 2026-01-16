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
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {
        var temp = stateMachine.blackboard.Get<float>("WanderingIndexTime") + Time.deltaTime;
        stateMachine.blackboard.Set("WanderingIndexTime", temp);
        float distance = Vector3.Distance(stateMachine.gameObject.transform.position,stateMachine.blackboard.Get<Vector3>("stopPoint"));
        if (distance < stopSlope)
        {
            var vec3temp = GetRandomPointOnNavMesh(stateMachine);
            stateMachine.blackboard.Set("stopPoint", vec3temp);
        }
        else
        {
            stateMachine.agent.SetDestination(stateMachine.blackboard.Get<Vector3>("stopPoint"));
        }
    }

    public override void ExitState(BaseStateMachine stateMachine)
    {
        stateMachine.agent.isStopped = true;
    }
    Vector3 GetRandomPointOnNavMesh(BaseStateMachine stateMachine)
    {
        Vector3 randomDirection = Random.insideUnitCircle * searchRange;
        Vector3 targetPosition = stateMachine.gameObject.transform.position + new Vector3(randomDirection.x, randomDirection.y, 0);

        NavMeshHit hit;
        if (NavMesh.SamplePosition(targetPosition, out hit, 1.0f, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return stateMachine.gameObject.transform.position;
    }

}
