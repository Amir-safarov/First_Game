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
        private bool _isRightDirection = true;
        private Vector3 localeScale;
        private float _horizontal;


        private const float ÑheckRadius = 0.2f;
        private const string JumpName = "Jump";
        private const string XAxis = "Horizontal";


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            _horizontal = Input.GetAxisRaw(XAxis);
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_horizontal * _movementSpeed, _rb.velocity.y);
        }

        internal void Jump()
        {
            if (Input.GetButtonDown(JumpName) && IsGrounded())
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            if (Input.GetButtonDown(JumpName) && _rb.velocity.y > 0f)
                _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 1f);
        }
        internal void Flip()
        {
            if ((_isRightDirection && _horizontal < 0f) || (!_isRightDirection && _horizontal > 0f))
            {
                _isRightDirection = !_isRightDirection;
                transform.Rotate(0, 180, 0);
            }
            /*{
                _isRightDirection = !_isRightDirection;
                localeScale = transform.localScale;
                localeScale.x *= -1f;
                transform.localScale = localeScale;
            }*/
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(_groundCheck.position, ÑheckRadius, _layerMask);
        }
    }
}
