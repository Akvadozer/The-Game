using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSpace;

namespace EnemySpace

{
    public class Bird : Slime
    {
        

        // Start is called before the first frame update
        void Start()
        {
            _startPosition = _enemyTransform.position;
        }

        // Update is called once per frame
        void Update()
        {
            BirdMovement();
            
        }

        private void BirdMovement()
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

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
        }


    }
}