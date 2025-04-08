using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerDeathCollider : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            player.Dead();
        }
    }
}
