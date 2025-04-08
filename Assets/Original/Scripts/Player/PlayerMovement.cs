using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string AnimationRunVariables = "Run";
    private const string HorizontalInput = "Horizontal";
    private const string JumpInput = "Jump";
    private const string RaycastLayerName = "Ground";
    
    private const float GroundCheckDistance = 0.1f;
    
    [SerializeField] private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField] private float _speed; 
    [SerializeField] private float _jumpForce;
   
    private Rigidbody2D _rb; 
    private float _moveInput;

    private void Awake()
    {
       _rb = GetComponent<Rigidbody2D>();
       _animator = GetComponentInChildren<Animator>();
       _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        MovementLogic();

        FlipLogic();
        
        JumpLogic();
        
        Debug.DrawLine(transform.position - new Vector3(0, transform.localScale.y), transform.position - new Vector3(0, transform.localScale.y) + Vector3.down * GroundCheckDistance, Color.red);
        
    }
    
    public void Jump(float force)
    {
        _rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }
    private void FlipLogic()
    {
        if (_moveInput >= 0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
    
    private void JumpLogic()
    {
        if (Input.GetButtonDown(JumpInput) && CheckGrounded())
        {
            Jump(_jumpForce);
        }
    }
    
    private void MovementLogic()
    {
        _moveInput = Input.GetAxis(HorizontalInput);
        Vector3 direction = transform.right * _moveInput;
        transform.Translate(direction * (_speed * Time.deltaTime));
        
        _animator.SetBool(AnimationRunVariables, _moveInput != 0);
    }

    private bool CheckGrounded()
    {
        bool isGrounded = false;

        Vector3 raycastStart = transform.position - new Vector3(0, transform.localScale.y);
        
        int groundMask = LayerMask.GetMask(RaycastLayerName);
        
        RaycastHit2D hit = Physics2D.Raycast(raycastStart, Vector2.down, GroundCheckDistance, groundMask);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            isGrounded = true;
        } 
        
        return isGrounded;
    }
}
