using UnityEngine;

public class BaseCondition : ScriptableObject
{
    public virtual bool Check(BaseStateMachine stateMachine)
    {
            return false;
    }

    [System.Serializable]
    public class Transition
    {
        public BaseCondition condition;
        public BaseState state;
    }
}
