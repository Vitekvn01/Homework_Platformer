using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FinishTrigger : MonoBehaviour
{
    public event Action OnFinishEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            OnFinishEvent?.Invoke();
        }
    }
    
}
