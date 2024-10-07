using UnityEngine;

namespace Game
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameScene _gameScene;

        private void Awake()
        {
            for (int i = 0; i < _gameScene.NpcSpawnPoints.Length; i++)
            {
                _gameScene.NpcSpawnPoints[i].Initialize(_gameScene);
            }
        }
    }
}