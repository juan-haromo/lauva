using UnityEngine;

[CreateAssetMenu(fileName = "StunState", menuName = "BaseEnemy/states/StunState")]
public class StunState : BaseState
{
    public override void EnterState(BaseStateMachine stateMachine)
    {
        stateMachine.trascendInteraction.SetActive(true);
        /*
        StateType = CallState.stun;
        stateMachine.blackboard.Set("StunIndexTime", 0f);
        */
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {
        /*
        
        var temp = stateMachine.blackboard.Get<float>("StunIndexTime") + Time.deltaTime;
        if (temp > 5)
        {
            Destroy(stateMachine.gameObject);
        }
        stateMachine.blackboard.Set("StunIndexTime", temp);
        */
       
    }

    public override void ExitState(BaseStateMachine stateMachine)
    {

    }
}
