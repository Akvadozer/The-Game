using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSpace
{

    public class MovementController : MonoBehaviour
    {
        internal float _moveInput;
        private Player _player;

        private void Start()
        {
            _player = GetComponent<Player>();
        }


        void Update()
        {
            _moveInput = Input.GetAxisRaw("Horizontal");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _player.Jump();
            }
            
        }

        
    }

}
