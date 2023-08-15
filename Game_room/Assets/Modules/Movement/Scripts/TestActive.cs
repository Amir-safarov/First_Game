using UnityEngine;

namespace Movement
{
    internal class TestActive : MonoBehaviour
    {
        [SerializeField] private MovementInput _character;
        private void Awake()
        {
            _character.Activate();
        }
    }
}
