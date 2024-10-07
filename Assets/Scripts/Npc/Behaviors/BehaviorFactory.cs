using System;
using Game;
using Movement;
using UnityEngine;

namespace Npc.Behaviors
{
    public static class BehaviorFactory
    {
        public static IBehavior CreateIdleBehavior(NpcIdleBehavior type, NpcMovement movement, Transform[] wayPoints)
        {
            return type switch
            {
                NpcIdleBehavior.Stand => new StandBehavior(movement),
                NpcIdleBehavior.Patrol => new PatrolBehavior(movement, wayPoints, movement.transform),
                NpcIdleBehavior.RandomMove => new RandomMoveBehavior(movement),
                
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
        
        public static IBehavior CreateReactionBehavior(NpcReactionBehavior type, NpcMovement movement, GameScene gameScene)
        {
            return type switch
            {
                NpcReactionBehavior.RunAway => new RunAwayBehavior(movement, movement.transform, gameScene),
                NpcReactionBehavior.Follow => new FollowBehavior(movement, movement.transform, gameScene),
                NpcReactionBehavior.Die => new DieBehavior(movement.gameObject),
                
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}