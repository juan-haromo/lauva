using UnityEngine;
using UnityEngine.AI;

public class BaseStateMachine : MonoBehaviour
{
    public BaseState initialState;
    [SerializeField] private BaseState currentState;
    public Blackboard blackboard = new Blackboard();
    public Transform target;
    public NavMeshAgent agent;
    public float maxPlayerDistance;



    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;     
        blackboard.Set("maxPlayerDistance",maxPlayerDistance);
        GameObject objeto = GameObject.FindWithTag("Player");
        if (!objeto)
        {
            target = objeto.transform;
        }
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