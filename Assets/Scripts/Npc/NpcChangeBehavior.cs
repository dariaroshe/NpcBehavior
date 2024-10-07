using DefaultNamespace;
using UnityEngine;

namespace Npc
{
    public class NpcChangeBehavior : MonoBehaviour
    {
        [SerializeField] private NpcStateExecutor _npcStateExecutor;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerTag>(out _))
            {
                _npcStateExecutor.SetState(NpcState.Reaction);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<PlayerTag>(out _))
            {
                _npcStateExecutor.SetState(NpcState.Idle);
            }
        }
    }
}