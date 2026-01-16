using UnityEngine;

[CreateAssetMenu(fileName = "LightSpeed",menuName = "Abilities/LightSpeed")]
public class LightSpeed : ScriptableObject, IAbility
{
    public float speed;
    public float duration;
    [SerializeField] float Cooldown;
    public void Activate(GameObject player)
    {
        player.GetComponent<PlayerMovement>().SpeedBoost(duration,speed);
    }

    float IAbility.Cooldown()=> Cooldown;
}