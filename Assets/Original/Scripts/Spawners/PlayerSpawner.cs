using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private CameraFollow _camera;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private Transform _startPos;

    private void Start()
    {
        PlayerSpawn();
    }

    private void PlayerSpawn()
    {
        Player player = Instantiate(_playerPrefab.gameObject, _startPos.position, Quaternion.identity).GetComponent<Player>();
        _camera.SetTarget(player.transform);
        _gameController.SetPlayer(player);
    }
}
