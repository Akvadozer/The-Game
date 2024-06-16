using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSpace;


namespace EnemySpace

{
    
    public class DestroyEnemy : MonoBehaviour
    {
        internal bool _deadEnemy;
        private Observer _observer;
        
        private void Start()
        {
            _observer = GetComponent<Observer>();
        }

        internal void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>() != null)
            {
                Destroy(this.gameObject);
                _deadEnemy = true;
            }
        }
    }
}