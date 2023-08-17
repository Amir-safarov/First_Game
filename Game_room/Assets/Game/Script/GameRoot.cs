using UnityEngine;
using Movement;
using Shooting;
internal class GameRoot : MonoBehaviour
{
    [SerializeField] private MovementInput _movementInput;
    //[SerializeField] private ShootingInput _shootingInput;

    private void Start()
    {
        _movementInput.Activate();
        //_shootingInput.Activate();
    }
}
