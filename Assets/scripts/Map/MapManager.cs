using UnityEngine;

public class MapManager : MonoBehaviour
{
    public MapManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}