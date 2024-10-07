using UnityEngine;

namespace Npc.Behaviors
{
    internal class DieBehavior : IBehavior
    {
        private readonly GameObject _gameObject;

        public DieBehavior(GameObject gameObject)
        {
            _gameObject = gameObject;
        }

        public void Execute()
        {
            Object.Destroy(_gameObject);
        }
    }
}