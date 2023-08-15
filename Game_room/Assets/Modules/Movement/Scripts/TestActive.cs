using UnityEngine;

namespace Movement
{
    internal class TestActive : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _character;
        private void Awake()
        {
            _character.Activate();
        }
    }
}
