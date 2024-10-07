using Movement;
using UnityEngine;

namespace Npc.Behaviors
{
    internal class RandomMoveBehavior : IBehavior
    {
        private readonly NpcMovement _movement;
        private float _timer;
        private float _changeDirectionCooldown = 1f;
        private Vector3 _randomDirection;

        public RandomMoveBehavior(NpcMovement movement)
        {
            _movement = movement;
        }

        public void Execute()
        {
            if (_timer >= _changeDirectionCooldown)
            {
                var randomX = Random.Range(-1f, 1f);
                var randomZ = Random.Range(-1f, 1f);

                _randomDirection = new Vector3(randomX, 0, randomZ);

                _timer = 0f;
            }
            else
            {
                _timer += Time.deltaTime;
            }
            
            _movement.SetDirection(_randomDirection);
        }
    }
}