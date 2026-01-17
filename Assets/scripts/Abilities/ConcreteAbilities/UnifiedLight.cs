using UnityEngine;

[CreateAssetMenu(fileName = "Unified Light",menuName = "Abilities/Unified Light")]
public class UnifiedLight : ScriptableObject, IAbility
{
    [SerializeField] float cooldown; 

    public void Activate(GameObject player)
    {
        TrascendedLightManger.Instance.UnifyLights(cooldown/4);
    }

    public float Cooldown()=>cooldown;
}