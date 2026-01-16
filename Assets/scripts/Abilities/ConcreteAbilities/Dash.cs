using UnityEngine;

[CreateAssetMenu(fileName = "Dash",menuName = "Abilities/Dash")]
public class Dash : ScriptableObject, IAbility
{
    public void Activate(GameObject player)
    {
        Debug.Log("Dash");
    }
}