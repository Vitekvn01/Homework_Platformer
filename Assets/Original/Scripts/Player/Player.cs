using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action OnDeadEvent;
    public void Dead()
    {
        OnDeadEvent?.Invoke();
        Destroy(gameObject);
    }
}
