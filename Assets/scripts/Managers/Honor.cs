using System;
using UnityEngine;
using UnityEngine.UI;

public class Honor : MonoBehaviour
{
    
    public static Honor Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("More than one honor in scene, destroying the one in " + name);
            Destroy(this);
        }
    }

    public int honorLevel;
    public float currentHonor;
    public float baseHonorCost; 
    float honorToLvlUp;
    public Image imgHonorProgress;
    public event HonorLevelUp OnLevelUp;

    public void AddHonor(float amount)
    {
        currentHonor += MathF.Abs(amount);
        if(honorToLvlUp <= currentHonor)
        {
            honorLevel++;
            currentHonor -= honorToLvlUp;
            honorToLvlUp += baseHonorCost  * Mathf.Pow(10,honorLevel); 
            OnLevelUp?.Invoke(this);
        }
    }
}

public delegate void HonorLevelUp(Honor honor);