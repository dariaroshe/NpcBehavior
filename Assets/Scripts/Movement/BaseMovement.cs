using UnityEngine;

namespace Movement
{
    public abstract class BaseMovement : MonoBehaviour
    {
        public float Speed;
        public float RotationSpeed;

        private void Update()
        {
            var direction = GetDirection();

            Move(direction.normalized * (Speed * Time.deltaTime));
            Rotate(direction);
        }

        protected abstract void Move(Vector3 movement);

        protected abstract Vector3 GetDirection();

        private void Rotate(Vector3 direction)
        {
            if (direction == Vector3.zero)
            {
                return;
            }
            
            direction.y = 0f;
            var lookRotation = Quaternion.LookRotation(direction);
            float step = RotationSpeed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
        }
    }
}