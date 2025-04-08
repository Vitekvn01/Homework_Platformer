using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private const float DistanceComplete =0.5f;
    
    [SerializeField] private float _speed;
    
    private SpriteRenderer _spriteRenderer;
    
    private float _radiusMovement;
    
    private Vector3 _startPos;
    private Vector3 _targetPos1;
    private Vector3 _targetPos2;
    private Vector3 _currentTarget;
    
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        _startPos = transform.position;
        _targetPos1 = new Vector3(_startPos.x + _radiusMovement / 2, transform.position.y,
            transform.position.z);
        _currentTarget = _targetPos1;
    }

    private void Update()
    {
        MovementLogic();
        
        FlipLogic();
    }
    
    public void Init(float radiusMovement)
    {
        _radiusMovement = radiusMovement;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (!Application.isPlaying)
        {
            Gizmos.DrawSphere(new Vector3(transform.position.x + _radiusMovement / 2, transform.position.y,
                transform.position.z), DistanceComplete);
            Gizmos.DrawSphere(new Vector3(transform.position.x - _radiusMovement / 2, transform.position.y,
                transform.position.z), DistanceComplete);
        }
        else
        {
            Gizmos.DrawSphere(_targetPos1, DistanceComplete);
            Gizmos.DrawSphere(_targetPos2, DistanceComplete);
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(_currentTarget, DistanceComplete);
        }
        
        
    }
    private void FlipLogic()
    {
        if (_currentTarget.x > transform.position.x)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
    
    private void MovementLogic()
    {
        _targetPos1 = new Vector3(_startPos.x + _radiusMovement / 2, transform.position.y,
            transform.position.z);
        _targetPos2 = new Vector3(_startPos.x - _radiusMovement / 2, transform.position.y,
            transform.position.z);

        _currentTarget.y = transform.position.y;
        _currentTarget.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, _currentTarget) <= DistanceComplete)
        {
            if (_currentTarget == _targetPos1)
            {
                _currentTarget = _targetPos2;
            }
            else
            {
                _currentTarget = _targetPos1;
            }
        }
    }
}
