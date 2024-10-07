using UnityEngine;

namespace Movement
{
    public class PlayerMovement : BaseCharacterMovement
    {
        private string _horizontalAxis = "Horizontal";
        private string _verticalAxis = "Vertical";

        protected override Vector3 GetDirection()
        {
            var directionX = Input.GetAxis(_horizontalAxis);
            var directionZ = Input.GetAxis(_verticalAxis);

            var direction = new Vector3(directionX, 0, directionZ);

            return direction;
        }
    }
}

