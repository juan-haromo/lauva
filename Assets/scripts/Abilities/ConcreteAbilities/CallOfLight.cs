using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CallOfLight",menuName = "Abilities/CallOfLight")]
public class CallOfLight : ScriptableObject, IAbility
{
    [SerializeField] float cooldown;
    [SerializeField] float radius;
    [SerializeField] float aggroMultiplier;
    [SerializeField] LayerMask enemyMask;
    public void Activate(GameObject player)
    {
        Collider[] enemies = Physics.OverlapSphere(player.transform.position,radius,enemyMask);
        foreach(Collider c in enemies)
        {
            if(c.TryGetComponent<BaseStateMachine>(out BaseStateMachine fsm))
            {
                fsm.IncreaseAggro(aggroMultiplier,cooldown/4);
            }
        }
    }

    public float Cooldown()=>cooldown;
}