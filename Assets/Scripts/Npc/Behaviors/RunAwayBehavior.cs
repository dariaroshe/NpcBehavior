using Game;
using Movement;
using UnityEngine;

namespace Npc.Behaviors
{
    internal class RunAwayBehavior : IBehavior
    {
        private readonly NpcMovement _movement;
        private readonly Transform _transform;
        private readonly GameScene _gameScene;

        public RunAwayBehavior(NpcMovement movement, Transform transform, GameScene gameScene)
        {
            _movement = movement;
            _transform = transform;
            _gameScene = gameScene;
        }

        public void Execute()
        {
            var direction = _transform.position - _gameScene.Player.position;
            _movement.SetDirection(direction);
        }
    }
}