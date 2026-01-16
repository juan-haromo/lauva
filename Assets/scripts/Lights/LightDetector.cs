using UnityEngine;

public class TrascendedLight : MonoBehaviour, ILightSource
{
    [SerializeField] LightType lightType;

    public LightType GetLightType()=>lightType;
}


public interface ILightSource
{
    public LightType GetLightType();
}

public enum LightType
{
    Cyan,
    Magenta,
    Yellow
}