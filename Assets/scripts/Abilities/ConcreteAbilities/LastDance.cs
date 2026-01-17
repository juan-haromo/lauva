using UnityEngine;

[CreateAssetMenu(fileName = "LastDance",menuName = "Abilities/LastDance")]
public class LastDance : ScriptableObject, IAbility
{
    [SerializeField] float cooldown;
    public void Activate(GameObject player)
    {
        Debug.Log("Last Dance");
    }

    public float Cooldown()=> cooldown;
}