using System;
using UnityEngine;

public class CoinWallet : MonoBehaviour
{
    public event Action<int> OnUpdateCoinCountEvent; 
    public int Count { get; private set; }

    public void AddCoin()
    {
        Count += 1;
        OnUpdateCoinCountEvent?.Invoke(Count);
    }
    

}
