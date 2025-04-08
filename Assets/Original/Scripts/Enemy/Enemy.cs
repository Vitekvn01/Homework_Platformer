using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action<Enemy> OnDeadEvent; 
    
    public void Dead()
    {
        OnDeadEvent?.Invoke(this);
        Destroy(gameObject);
    }
}
