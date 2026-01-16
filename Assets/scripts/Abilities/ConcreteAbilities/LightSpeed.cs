using UnityEngine;

[CreateAssetMenu(fileName = "LightSpeed",menuName = "Abilities/LightSpeed")]
public class LightSpeed : ScriptableObject, IAbility
{
    public void Activate(GameObject player)
    {
        Debug.Log("Light Speed");
    }
}