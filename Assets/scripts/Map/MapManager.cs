using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            Debug.Log("instance");
        }
        else
        {
            Destroy(this);
        }
    }

    public void SpawnEnemy(Transform spawnPos, GameObject enemyGO)
    {
        Instantiate(enemyGO, spawnPos);
    }
}