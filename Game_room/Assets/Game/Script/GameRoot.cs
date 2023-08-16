using UnityEngine;
using Movement;

internal class GameRoot : MonoBehaviour
{
    [SerializeField] private MovementInput _input;

    private void Start()
    {
        _input.Activate();
    }
}
