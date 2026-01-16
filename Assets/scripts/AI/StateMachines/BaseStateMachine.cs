using System;
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
    public LightType lightType;



    private void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;     
        blackboard.Set("maxPlayerDistance",maxPlayerDistance);
        blackboard.Set("StunTime", 0.0f);
        blackboard.Set("trascend", false);
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

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<ILightSource>(out ILightSource sourceType))
        {
            if(sourceType.GetLightType() != lightType){return;}

            var temp = blackboard.Get<float>("StunTime") + Time.deltaTime;
            blackboard.Set("StunTime", temp);
            Debug.Log(temp + " " + name);
        }
    }

    public void Trascend()
    {
        blackboard.Set("trascend", true);
    }
}