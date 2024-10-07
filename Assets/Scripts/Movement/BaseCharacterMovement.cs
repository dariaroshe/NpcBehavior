using UnityEngine;

namespace Movement
{
    public abstract class BaseCharacterMovement : BaseMovement
    {
        [SerializeField] private CharacterController _characterController;

        protected override void Move(Vector3 movement)
        {
            _characterController.Move(movement);
        }
    }
}