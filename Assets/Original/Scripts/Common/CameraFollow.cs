using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    
    [SerializeField] private float _speed; 
    [SerializeField] private float _minBounds; 
    [SerializeField] private float _maxBounds;

    private Camera _camera;
    private Transform _target;

    private void LateUpdate()
    {
        FollowLogic();
    }
    
    private void OnDrawGizmos()
    {
        float height = Camera.main.orthographicSize * 2;
        float width = height * Camera.main.aspect;
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(_minBounds - width/2, -100f), new Vector3(_minBounds - width/2, 100f));
        Gizmos.DrawLine(new Vector3(_maxBounds + width/2, -100f), new Vector3(_maxBounds + width/2, 100f));
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
    
    private void FollowLogic()
    {
        if (_target != null)
        {
            Vector3 desiredPosition = _target.position + _offset;
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, _minBounds, _maxBounds);
            
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, _speed);
        }
    }


}
