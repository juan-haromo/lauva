using System.Collections;
using UnityEngine;

public class TrascendedLightManger : MonoBehaviour
{
    public static bool AreLightsUnified{get; private set;}

    public static TrascendedLightManger Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(this);
        }
    }

    public void UnifyLights(float time)
    {
        StartCoroutine(Unification(time));
    }

    IEnumerator Unification(float time)
    {
        AreLightsUnified = true;
        yield return new WaitForSeconds(time);
        AreLightsUnified = false;
    }
}