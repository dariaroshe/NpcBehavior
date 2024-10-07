using System.Collections.Generic;
using Game;
using Movement;
using Npc.Behaviors;
using UnityEngine;

namespace Npc
{
    public class NpcStateExecutor : MonoBehaviour
    {
        [SerializeField] private NpcMovement _npcMovement;
        [SerializeField] private ParticleSystem _dieFxPrefab;

        private readonly Dictionary<NpcState, IBehavior> _stateBehaviors = new();
        
        private NpcState _currentState;

        private void Update()
        {
            _stateBehaviors[_currentState].Execute();
        }

        public void Initialize(GameScene gameScene, Transform[] wayPoints, NpcIdleBehavior npcIdleBehavior, NpcReactionBehavior npcReactionBehavior)
        {
            _stateBehaviors.Add(NpcState.Idle, BehaviorFactory.CreateIdleBehavior(npcIdleBehavior, _npcMovement, wayPoints));
            _stateBehaviors.Add(NpcState.Reaction, BehaviorFactory.CreateReactionBehavior(npcReactionBehavior, _npcMovement, gameScene, _dieFxPrefab));
        }

        public void SetState(NpcState npcState)
        {
            _currentState = npcState;
        }
    }
}