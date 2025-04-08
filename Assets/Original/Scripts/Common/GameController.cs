using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private FinishTrigger _finishTrigger;
    
    private Player _player;

    public event Action OnWinEvent;
    public event Action OnLoseEvent;

    private void Start()
    {
        _finishTrigger.OnFinishEvent += Win;
    }
    
    public void SetPlayer(Player player)
    {
        _player = player;
        _player.OnDeadEvent += Lose;
    }
    
    public void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        SceneManager.LoadScene(currentScene.name);
    }
    private void Win()
    {
        Debug.Log("Победа");
        OnWinEvent?.Invoke();
        _finishTrigger.OnFinishEvent -= Win;
    }
    
    private void Lose()
    {
        Debug.Log("Проигрыш");
        OnLoseEvent?.Invoke();
        _player.OnDeadEvent -= Lose;
    }


}
