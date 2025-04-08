using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    public event Action OnPickupCoinEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            OnPickupCoinEvent?.Invoke();
            Destroy(gameObject);
        }
    }
    
}
