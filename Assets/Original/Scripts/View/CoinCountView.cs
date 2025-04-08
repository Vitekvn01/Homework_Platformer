using TMPro;
using UnityEngine;

public class CoinCountView : MonoBehaviour
{
    [SerializeField] private CoinWallet _coinWallet;
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _coinWallet.OnUpdateCoinCountEvent += UpdateCoinText;
    }

    private void OnDestroy()
    {
        _coinWallet.OnUpdateCoinCountEvent -= UpdateCoinText;
    }

    private void UpdateCoinText(int newCount)
    {
        _text.text = newCount.ToString();
    }
}
