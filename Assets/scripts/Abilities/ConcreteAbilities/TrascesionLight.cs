using UnityEngine;

[CreateAssetMenu(fileName = "TrascesionLight",menuName = "Abilities/TrascesionLight")]
public class TrascesionLight : ScriptableObject, IAbility
{
    public void Activate(GameObject player)
    {
        Debug.Log("Trascesion Light");
    }
}