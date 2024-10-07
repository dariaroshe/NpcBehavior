using Game;
using UnityEngine;

namespace Npc
{
    public class NpcSpawnPoint : MonoBehaviour
    {
        [SerializeField] private NpcStateExecutor _prefab;
        [SerializeField] private NpcIdleBehavior _npcIdleBehavior;
        [SerializeField] private NpcReactionBehavior _npcReactionBehavior;

        [SerializeField] private Transform[] _wayPoints;
        
        private GameScene _gameScene;

        public void Initialize(GameScene gameScene)
        {
            _gameScene = gameScene;
        }

        private void Start()
        {
            var npc = Instantiate(_prefab, transform.position, transform.rotation);
            npc.Initialize(_gameScene, _wayPoints, _npcIdleBehavior, _npcReactionBehavior);
        }
    }
}
