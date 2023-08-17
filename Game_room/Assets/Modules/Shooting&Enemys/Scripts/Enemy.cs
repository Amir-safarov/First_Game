using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingAndEnemys
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private float _speed;
        [SerializeField] private Transform _targetPlayer;

        private Rigidbody2D _rb;
        private float _distance;

        private const float _distanceRange = 1.05f;
        private const float _maxJumpValue = 0.9f;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            _distance = Vector2.Distance(transform.position, _targetPlayer.position);
            if (_distance <= _distanceRange)
            {
                _rb.velocity = Vector2.zero;
                _rb.bodyType = RigidbodyType2D.Kinematic; 
            }
            else
            {
                _rb.bodyType = RigidbodyType2D.Dynamic; 
                if (Mathf.Abs(transform.position.y - _targetPlayer.position.y) <= _maxJumpValue)
                {
                    Vector2 direction = (_targetPlayer.position - transform.position).normalized;
                    _rb.velocity = direction * _speed;
                }
                else
                    _rb.velocity = Vector2.zero;
            }
        }
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health >= 0)
                Destroy(gameObject);
        }
    }
}
