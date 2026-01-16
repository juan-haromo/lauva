using UnityEngine;

[CreateAssetMenu(fileName = "Unified Light",menuName = "Abilities/Unified Light")]
public class UnifiedLight : ScriptableObject, IAbility
{
    public void Activate(GameObject player)
    {
        Debug.Log("Unified Light");
    }
}