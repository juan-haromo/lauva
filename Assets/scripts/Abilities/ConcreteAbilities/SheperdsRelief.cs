using UnityEngine;

[CreateAssetMenu(fileName = "SheperdsRelief",menuName = "Abilities/SheperdsRelief")]
public class SheperdsRelief : ScriptableObject, IAbility
{
    public void Activate(GameObject player)
    {
        Debug.Log("Sheperds Relief");
    }
}