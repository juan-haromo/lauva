using UnityEngine;

[CreateAssetMenu(fileName = "TrascesionLight",menuName = "Abilities/TrascesionLight")]
public class TrascesionLight : ScriptableObject, IAbility
{
    [SerializeField] float cooldown;
    public void Activate(GameObject player)
    {
        Debug.Log("Trascesion Light");
    }

    public float Cooldown()=> cooldown;
}