using UnityEngine;

[CreateAssetMenu(fileName = "TrascesionLight",menuName = "Abilities/TrascesionLight")]
public class TrascesionLight : ScriptableObject, IAbility
{
    [SerializeField] float cooldown;
    public void Activate(GameObject player)
    {
        player.GetComponent<PlayerMovement>().Transcend(cooldown/3);
    }

    public float Cooldown()=> cooldown;
}