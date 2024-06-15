using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace PlayerSpace

{

    public class Player : MonoBehaviour
    {
        [SerializeField] internal int _lives;
        [SerializeField] private TMP_Text _text;
        
        [Header("Movement")] 
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;
        internal bool _isMove;
        internal bool _isFlip = true;
        internal bool _isHit;
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
            _text.gameObject.SetActive(false); // текст о смерти невидимый на старте

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

        internal void Damage()
        {
            if (!Dead())
            {
                _lives--;
                Debug.Log(" lives " + _lives);
                // добавляем метод убавления сердечек на экране вместо текста с жизнями
                //_isHit = true;
            }
            else
            {
                ShowText();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }

        internal bool Dead()
        {
            return _lives <= 0 ? true : false;
        }
        
        private void ShowText()
        {
            _text.text = " Dead! "; // Устанавливаем текст сообщения
            _text.gameObject.SetActive(true); // Делаем текст видимым
        }

    }
}
