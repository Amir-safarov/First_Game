using UnityEngine;

namespace Shooting
{
    internal class Bullet : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _lifeTime;

        private Rigidbody2D _bullet;

        private void Awake()
        {
            _bullet = GetComponent<Rigidbody2D>();
            _bullet.velocity = transform.right * _bulletSpeed;
            Destroy(gameObject, _lifeTime);
        }

    }
}
