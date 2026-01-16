using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    public BaseState initialState;
    [SerializeField] private BaseState currentState;

    private void Start()
    {
        currentState = initialState;
    }

    private void Update()
    {
        currentState.UpdateState(this);
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
