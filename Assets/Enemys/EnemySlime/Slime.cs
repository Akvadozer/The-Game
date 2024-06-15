using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using PlayerSpace;

namespace EnemySpace
{
    public class Slime : MonoBehaviour
    {
        [SerializeField] protected float _speed;
        [SerializeField] protected float _distance;
        internal bool _moveLeft = true;

        
        [SerializeField] protected Transform _enemyTransform;
        protected Vector3 _startPosition;
        protected Player _player;


        public delegate void EnemyHit();

        public static event EnemyHit OnEnemyHit ;
        
        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>() != null)
            {
                OnEnemyHit?.Invoke();
            }
        }
        
        
        void Start()
        {
            _startPosition = _enemyTransform.position; // стартовая позиция, обозначаем
            
        }


        private void Update()
        {
            SlimeMovement();
        }

        private void FixedUpdate()
        {
            
        }


        private void SlimeMovement()
        {
            
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

      
    }
}

