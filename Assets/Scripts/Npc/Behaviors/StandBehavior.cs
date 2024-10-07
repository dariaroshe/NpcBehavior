using Movement;
using UnityEngine;

namespace Npc.Behaviors
{
    public class StandBehavior : IBehavior
    {
        private readonly NpcMovement _movement;

        public StandBehavior(NpcMovement movement)
        {
            _movement = movement;
        }
        
        public void Execute()
        {
            _movement.SetDirection(Vector3.zero);
        }
    }
}