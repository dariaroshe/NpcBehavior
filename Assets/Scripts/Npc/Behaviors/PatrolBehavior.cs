using Movement;
using UnityEngine;

namespace Npc.Behaviors
{
    internal class PatrolBehavior : IBehavior
    {
        private readonly NpcMovement _movement;
        private readonly Transform[] _wayPoints;
        private readonly Transform _transform;
        private int _pointIndex;
        private float _deadZone = 0.1f;

        public PatrolBehavior(NpcMovement movement, Transform[] wayPoints, Transform transform)
        {
            _movement = movement;
            _wayPoints = wayPoints;
            _transform = transform;
        }

        public void Execute()
        {
            if (_pointIndex >= _wayPoints.Length)
            {
                _pointIndex = 0;
            }
                    
            var direction = _wayPoints[_pointIndex].position - _transform.position;
            _movement.SetDirection(direction);

            var distance = Vector3.Distance(_wayPoints[_pointIndex].position, _transform.position);

            if (distance < _deadZone)
            {
                _pointIndex++;
            }
        }
    }
}