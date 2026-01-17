using UnityEngine;

[CreateAssetMenu(fileName = "SheperdsRelief",menuName = "Abilities/SheperdsRelief")]
public class SheperdsRelief : ScriptableObject, IAbility
{
    [SerializeField] float cooldown;
    public void Activate(GameObject player)
    {
        Debug.Log("Sheperds Relief");
    }

    public float Cooldown()=> cooldown;
}