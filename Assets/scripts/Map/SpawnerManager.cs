using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public List<Transform> spawnTransforms = new List<Transform>();
    public GameObject enemyPrefab;

    private void Start()
    {
        int temp = Random.Range(5, 10);
        spawnEnemies(temp);
    }

    public void spawnEnemies(int spawnAmount)
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            int temp = Random.Range(0, spawnTransforms.Count);
            MapManager.Instance.SpawnEnemy(spawnTransforms[temp],enemyPrefab);
        }
    }
    
}
