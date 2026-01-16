using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    public BaseState initialState;
    [SerializeField] private BaseState currentState;
    public Blackboard blackboard = new Blackboard();

    private void Start()
    {
        ChangeState(initialState);
    }

    private void Update()
    {
        if (currentState)
        {
            currentState.UpdateState(this);
            currentState.CheckTransitions(this, currentState.StateType);
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (newState == currentState || newState == null)
        {
            return;
        }

        if (currentState != null)
        {
            currentState.ExitState(this);
        }

        currentState = newState;
        currentState.EnterState(this);
    }
}