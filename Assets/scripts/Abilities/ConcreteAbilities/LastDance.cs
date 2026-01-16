using UnityEngine;

[CreateAssetMenu(fileName = "LastDance",menuName = "Abilities/LastDance")]
public class LastDance : ScriptableObject, IAbility
{
    public void Activate(GameObject player)
    {
        Debug.Log("Last Dance");
    }
}