using UnityEngine;

namespace Movement
{
    public class NpcMovement : BaseCharacterMovement
    {
        private Vector3 _direction;
        
        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }
        
        protected override Vector3 GetDirection()
        {
            return _direction;
        }
    }
}