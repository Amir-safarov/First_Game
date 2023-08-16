using UnityEngine;

internal class Shoot : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPosirion;
    [SerializeField] private GameObject _bulletPrefab;
/*    [SerializeField] private float _bulletCoolDown;

    private float _lastFiredTime;
*/
    /*internal void CoolDown()
    {
        if (Time.time - _lastFiredTime >= _bulletCoolDown)
        {
            SpawnBullet();
            _lastFiredTime = Time.time;
        }
    }*/
    internal void SpawnBullet()
    {
        Instantiate(_bulletPrefab, _bulletSpawnPosirion.position, transform.rotation);
    }

}
