using UnityEngine;

namespace PlayerSpace
{

    public class Player : MonoBehaviour
    {
        [SerializeField] private int _lives;
        
        [Header("Movement")] 
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        internal bool _isMove;
        internal bool _isFlip = true;
        private int _doubleJump = 2;


        [Header("CollisionInfo")] 
        [SerializeField] private Transform _checkTransform;
        [SerializeField] private float _groundCheckdRadius;
        [SerializeField] private LayerMask _groundLayerMask;
        internal bool _isGrounded;


        private MovementController _movementController;
        internal Rigidbody2D _rb;



        void Start()
        {
            _movementController = GetComponent<MovementController>();
            _rb = GetComponent<Rigidbody2D>();

        }


        void Update()
        {
            _isMove = _rb.velocity.x != 0;
            Flip();
            CollisionCheck();

        }


        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(_movementController._moveInput * _speed, _rb.velocity.y);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_checkTransform.position, _groundCheckdRadius);
        }

        private void CollisionCheck()
        {
            _isGrounded = Physics2D.OverlapCircle(_checkTransform.position, _groundCheckdRadius, _groundLayerMask);

        }



        private void Flip()
        {
            if ((_rb.velocity.x > 0 && !_isFlip) || (_rb.velocity.x < 0 && _isFlip))
            {
                _isFlip = !_isFlip;
                transform.Rotate(0, 180, 0);
            }
        }
        
        
        internal void Jump()
        {
            if (_isGrounded)
            {
                _doubleJump = 2;
            }
            

            if (_doubleJump > 0 )
            {
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
                _doubleJump--;
            }

        }


    }
}
