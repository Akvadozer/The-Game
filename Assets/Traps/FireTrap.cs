using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TrapSpace
{
    public class FireTrap : Trap
    {

        private Animator _animator;
        private bool _isWorking;
        [SerializeField] private float _cooldown;
        private float _cooldownTimer;



        void Start()
        {
            _animator = GetComponent<Animator>();
        }


        void Update()
        {
            _cooldownTimer -= Time.deltaTime;
            if (_cooldownTimer < 0)
            {
                _isWorking = !_isWorking;
                _cooldownTimer = _cooldown;
            }

            _animator.SetBool("isWorking", _isWorking);
        }

        protected override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
        }
    }
}