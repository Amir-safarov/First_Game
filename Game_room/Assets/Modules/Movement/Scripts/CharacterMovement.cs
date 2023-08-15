using UnityEngine;

namespace Movement
{
    internal class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _jumpForce;

        private Rigidbody2D _rb;
        private float _horizontal;
        private bool _isRightDirection = true;
        private Vector3 localeScale;
        private bool _active = false;

        private const string XAxis = "Horizontal";
        private const string JumpName = "Jump";
        private const float ÑheckRadius = 0.2f;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if(_active==false)
                return;
            _horizontal = Input.GetAxisRaw(XAxis);
            Flip();
            Jump();
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_horizontal * _movementSpeed, _rb.velocity.y);
        }

        private void Jump()
        {
            if (Input.GetButtonDown(JumpName) && IsGrounded())
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            if (Input.GetButtonDown(JumpName) && _rb.velocity.y > 0f)
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 1f);
        }
        private void Flip()
        {
            if((_isRightDirection && _horizontal <0f) || (!_isRightDirection && _horizontal > 0f))
            {
                _isRightDirection = !_isRightDirection;
                localeScale = transform.localScale;
                localeScale.x *= -1f;
                transform.localScale = localeScale;
            }
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, ÑheckRadius, _layerMask);
        }

        public void Activate()
        {
            _active = true;
        }
        public void Deactivate()
        {
            _active = false;
        }

    }
}
