using UnityEngine;

public class EnemyDeathCollider : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement player))
        {
            player.Jump(_jumpForce);
            _enemy.Dead();
        }
    }
}
