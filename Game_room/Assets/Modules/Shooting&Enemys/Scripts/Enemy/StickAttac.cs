using UnityEngine;
namespace ShootingAndEnemys
{
    internal class StickAttac : MonoBehaviour
    {
        [SerializeField, Range(1, 40)] private int _stickDamage;
        [SerializeField] private Transform _targetPlayer;
        [SerializeField] private Animator _animator;

        private const float _distanceRange = 3.5f;
        private float _distance;

        private void FixedUpdate()
        {
            _distance = Vector2.Distance(transform.position, _targetPlayer.position);
            if (_distance <= _distanceRange)
                _animator.SetBool("startAttac", true);
            else
                _animator.SetBool("startAttac", false);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            CharacterStats character = collision.gameObject.GetComponent<CharacterStats>();
            if (character != null)
            {
                character.TakeDamage(_stickDamage);
                Debug.Log("Перс атакован");
            }
        }


    }
}
