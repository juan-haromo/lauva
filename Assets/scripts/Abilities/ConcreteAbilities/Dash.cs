using UnityEngine;

[CreateAssetMenu(fileName = "Dash",menuName = "Abilities/Dash")]
public class Dash : ScriptableObject, IAbility
{
    [SerializeField] float cooldown;
    [SerializeField] float dashSpeed;

    public void Activate(GameObject player)
    {
        PlayerMovement movement = player.GetComponent<PlayerMovement>();
        movement.Controller.Move(movement.LastMovement * dashSpeed);
    }

    public float Cooldown()=> cooldown;
}