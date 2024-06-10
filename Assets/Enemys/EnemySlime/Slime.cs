using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using PlayerSpace;

namespace SlimeSpace
{
    public class Slime : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _distance;
        private bool _moveLeft = true;

        
        [SerializeField] private Transform _enemyTransform;
        private Vector3 _startPosition;
        private Player _player;
        
        
        
        void Start()
        {
            _startPosition = _enemyTransform.position; // стартовая позиция, обозначаем
        }


        void Update()
        {
            SlimeMovement();
        }

        private void SlimeMovement()
        {
            // _enemy.transform.position = Vector3.MoveTowards(_enemyTransform.position, new Vector3( (float)-2.5 , (float)-3.5 , 0), _speed * Time.deltaTime);
            if (_moveLeft)
            {
                transform.Translate(Vector3.left * (_speed * Time.deltaTime));
                if (Vector3.Distance(_startPosition, _enemyTransform.position) >= _distance)
                {
                    _moveLeft = false;

                }
            }
            else
            {
                transform.Translate(Vector3.right * (_speed * Time.deltaTime));
                if (Vector3.Distance(_startPosition, _enemyTransform.position) >= _distance)
                {
                    _moveLeft = true;
                }
            }
        }

       private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>() != null)
            {
                _player.Damage();
            }
        }
    }
}

