using UnityEngine;

namespace Shooting
{
    public class ShootingInput : MonoBehaviour
    {
        [SerializeField] private Shoot _shootedObject;
        [SerializeField, Range(0.1f, 3f)] private float _bulletCoolDown;

        private float _lastFiredTime;

        private bool _active = false;

        private void Update()
        {
            if (_active == false)
                return;
            CoolDown();
        }

        internal void CoolDown()
        {
            if (Time.time - _lastFiredTime >= _bulletCoolDown)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    _shootedObject.SpawnBullet();
                    _lastFiredTime = Time.time;
                }
            }
        }
        public void Activate()
        {
            _active = true;
        }
        public void Deactivate()
        {
            _active = false;
        }
    }
}
