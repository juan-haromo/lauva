using UnityEngine;

[CreateAssetMenu(fileName = "CallOfLight",menuName = "Abilities/CallOfLight")]
public class CallOfLight : ScriptableObject, IAbility
{
    public void Activate(GameObject player)
    {
        Debug.Log("Call Of Light");
    }
}