using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{   
    [SerializeField] private CoinWallet _coinWallet;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Enemy> _enemies;
    
    private void OnDestroy()
    {
        List<Enemy> enemiesCopy = new List<Enemy>(_enemies);
        
        foreach (Enemy enemy in enemiesCopy)
        {
            if (enemy != null)
            {
                UnsubscriptionEvent(enemy);
            }
        }
    }
    public void SubscriptionEvent(Enemy enemy)
    {
        _enemies.Add(enemy);
        
        enemy.OnDeadEvent += SpawnCoin;
        enemy.OnDeadEvent += UnsubscriptionEvent;
    }
    
    private void SpawnCoin(Enemy enemy)
    {
       Coin coin = Instantiate(_coinPrefab.gameObject, enemy.transform.position, quaternion.identity).GetComponent<Coin>();
       coin.OnPickupCoinEvent += _coinWallet.AddCoin;
    }

    private void UnsubscriptionEvent(Enemy enemy)
    {
        _enemies.Remove(enemy);
        
        enemy.OnDeadEvent -= SpawnCoin;
        enemy.OnDeadEvent -= UnsubscriptionEvent;
    }

    
}
