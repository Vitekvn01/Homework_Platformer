using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    private const float DistanceComplete = 0.5f;
    
   [SerializeField] private float _enemyRadiusMovement;

   public float EnemyRadiusMovement => _enemyRadiusMovement;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (!Application.isPlaying)
        {
            Gizmos.DrawSphere(new Vector3(transform.position.x + _enemyRadiusMovement / 2, transform.position.y,
                transform.position.z), DistanceComplete);
            Gizmos.DrawSphere(new Vector3(transform.position.x - _enemyRadiusMovement / 2, transform.position.y,
                transform.position.z), DistanceComplete);
        }
    }
}
