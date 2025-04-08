using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<EnemySpawnPoint> _spawnPoints;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        foreach (EnemySpawnPoint point in _spawnPoints)
        {
            Enemy enemy = Instantiate(_enemyPrefab.gameObject, point.transform.position, Quaternion.identity)
                .GetComponent<Enemy>();
            
            _coinSpawner.SubscriptionEvent(enemy);
            
            EnemyMovement enemyMovement = enemy.gameObject.GetComponent<EnemyMovement>();
            enemyMovement.Init(point.EnemyRadiusMovement);
        }
    }
    
}
