using Game;
using Movement;
using UnityEngine;

namespace Npc.Behaviors
{
    internal class FollowBehavior : IBehavior
    {
        private readonly NpcMovement _movement;
        private readonly Transform _transform;
        private readonly GameScene _gameScene;

        public FollowBehavior(NpcMovement movement, Transform transform, GameScene gameScene)
        {
            _movement = movement;
            _transform = transform;
            _gameScene = gameScene;
        }

        public void Execute()
        {
            var direction =  _gameScene.Player.position - _transform.position;
            _movement.SetDirection(direction);
        }
    }
}