using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGamePanel : MonoBehaviour
{
    private const string WinText = "Win";
    private const string LoseText = "Lose";
    private const string ButtonText = "Restart";
    
    [SerializeField] private GameController _gameController;
    [SerializeField] private GameObject _endGamePanel;
    
    [SerializeField] private TextMeshProUGUI _endGameText;
    [SerializeField] private TextMeshProUGUI _buttonText;
    
    [SerializeField] private Button _button;

    private void OnDestroy()
    {
        _gameController.OnWinEvent -= ShowWin;
        _gameController.OnLoseEvent -= ShowLose;
    }
    
    private void Awake()
    {
        _buttonText.text = ButtonText;
        _button.onClick.AddListener(_gameController.RestartLevel);
    }

    private void Start()
    {
        _gameController.OnWinEvent += ShowWin;
        _gameController.OnLoseEvent += ShowLose;
    }

    private void ShowWin()
    {
        _endGameText.text = WinText;
        _endGamePanel.SetActive(true);
    }

    private void ShowLose()
    {
        _endGameText.text = LoseText;
        _endGamePanel.SetActive(true);
    }


}
