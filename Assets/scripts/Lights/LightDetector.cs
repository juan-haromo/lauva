using UnityEngine;

public class TrascendedLight : MonoBehaviour, ILightSource
{
    [SerializeField] LightType lightType;
    public static bool areLightsUnified;

    public LightType GetLightType()=>lightType;
}


public interface ILightSource
{
    public LightType GetLightType();
}

public enum LightType
{
    Pink,
    Yellow,
    Green,
    Purple

}