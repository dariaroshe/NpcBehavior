using System;
using DefaultNamespace;
using Movement;
using Npc.Behaviors;
using UnityEngine;

namespace Npc
{
    public class NpcStateExecutor : MonoBehaviour
    {
        [SerializeField] private NpcMovement _npcMovement;
        
        private NpcState _currentState;
        private IBehavior _npcIdleBehavior;
        private IBehavior _npcReactionBehavior;
        private GameScene _gameScene;
        private Transform[] _wayPoints;

        private void Update()
        {
            switch (_currentState)
            {
                case NpcState.Idle:
                {
                    _npcIdleBehavior.Execute();
                    break;
                }
                case NpcState.Reaction:
                {
                    _npcReactionBehavior.Execute();
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Initialize(GameScene gameScene, Transform[] wayPoints, NpcIdleBehavior npcIdleBehavior, NpcReactionBehavior npcReactionBehavior)
        {
            _gameScene = gameScene;
            _wayPoints = wayPoints;
            
            _npcIdleBehavior = CreateIdleBehavior(npcIdleBehavior);
            _npcReactionBehavior = CreateReactionBehavior(npcReactionBehavior);
        }

        public void SetState(NpcState npcState)
        {
            _currentState = npcState;
        }

        private IBehavior CreateIdleBehavior(NpcIdleBehavior type)
        {
            return type switch
            {
                NpcIdleBehavior.Stand => new StandBehavior(_npcMovement),
                NpcIdleBehavior.Patrol => new PatrolBehavior(_npcMovement, _wayPoints, transform),
                NpcIdleBehavior.RandomMove => new RandomMoveBehavior(_npcMovement),
                
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
        
        private IBehavior CreateReactionBehavior(NpcReactionBehavior type)
        {
            return type switch
            {
                NpcReactionBehavior.RunAway => new RunAwayBehavior(_npcMovement, transform, _gameScene),
                NpcReactionBehavior.Follow => new FollowBehavior(_npcMovement, transform, _gameScene),
                NpcReactionBehavior.Die => new DieBehavior(gameObject),
                
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}