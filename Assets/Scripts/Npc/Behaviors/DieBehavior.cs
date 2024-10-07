using UnityEngine;

namespace Npc.Behaviors
{
    internal class DieBehavior : IBehavior
    {
        private readonly GameObject _gameObject;
        private readonly ParticleSystem _dieFxPrefab;

        public DieBehavior(GameObject gameObject, ParticleSystem dieFxPrefab)
        {
            _gameObject = gameObject;
            _dieFxPrefab = dieFxPrefab;
        }

        public void Execute()
        {
            Object.Destroy(_gameObject);
            Object.Instantiate(_dieFxPrefab, _gameObject.transform.position, Quaternion.identity);
        }
    }
}