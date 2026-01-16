using UnityEngine;

public class BaseCondition : ScriptableObject
{
    public class Condition : ScriptableObject
    {
        public virtual bool Check(BaseStateMachine stateMachine)
        {
            return false;
        }
    }

    [System.Serializable]
    public class Transition
    {
        public Condition condition;
        public BaseState state;
    }
}
