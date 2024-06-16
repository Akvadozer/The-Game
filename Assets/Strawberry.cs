using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSpace;

namespace StrawSpace
{


    public class Strawberry : MonoBehaviour
    {
        private Player _player;
        internal GameObject _strawberry;

        public delegate void Straw();

        public static event Straw OnStraw;




        // Start is called before the first frame update
        void Start()
        {
            _player = GetComponent<Player>();

        }

        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<Player>() != null)
            {
                OnStraw?.Invoke();
                Destroy(this.gameObject);
            }
        }
    }
}