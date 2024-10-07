using System;
using DefaultNamespace;
using Movement;
using Npc.Behaviors;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Npc
{
    public class NpcStateExecutor : MonoBehaviour
    {
        [SerializeField] private NpcMovement _npcMovement;
        
        private NpcState _currentState;
        private NpcIdleBehavior _npcIdleBehavior;
        private NpcReactionBehavior _npcReactionBehavior;
        private GameScene _gameScene;
        private Transform[] _wayPoints;
        private float _deadZone = 0.1f;
        private int _pointIndex;
        private Vector3 _randomDirection;
        private float _timer;
        private float _changeDirectionCooldown = 1f;

        private void Update()
        {
            switch (_currentState)
            {
                case NpcState.Idle:
                {
                    Idle();
                    break;
                }
                case NpcState.Reaction:
                {
                    Reaction();
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Initialize(GameScene gameScene, Transform[] wayPoints)
        {
            _gameScene = gameScene;
            _wayPoints = wayPoints;
        }

        public void SetState(NpcState npcState)
        {
            _currentState = npcState;
        }

        public void SetBehaviors(NpcIdleBehavior npcIdleBehavior, NpcReactionBehavior npcReactionBehavior)
        {
            _npcIdleBehavior = npcIdleBehavior;
            _npcReactionBehavior = npcReactionBehavior;
        }

        private void Idle()
        {
            switch (_npcIdleBehavior)
            {
                case NpcIdleBehavior.Stand:
                {
                    var direction = Vector3.zero;
                    _npcMovement.SetDirection(direction);
                    break;
                }
                case NpcIdleBehavior.Patrol:
                {
                    if (_pointIndex >= _wayPoints.Length)
                    {
                        _pointIndex = 0;
                    }
                    
                    var direction = _wayPoints[_pointIndex].position - transform.position;
                    _npcMovement.SetDirection(direction);

                    var distance = Vector3.Distance(_wayPoints[_pointIndex].position, transform.position);

                    if (distance < _deadZone)
                    {
                        _pointIndex++;
                    }
                    
                    break;
                }
                case NpcIdleBehavior.RandomMove:
                {
                    if (_timer >= _changeDirectionCooldown)
                    {
                        var randomX = Random.Range(-1f, 1f);
                        var randomZ = Random.Range(-1f, 1f);

                        _randomDirection = new Vector3(randomX, 0, randomZ);

                        _timer = 0f;
                    }
                    else
                    {
                        _timer += Time.deltaTime;
                    }
                    _npcMovement.SetDirection(_randomDirection);
                    
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void Reaction()
        {
            switch (_npcReactionBehavior)
            {
                case NpcReactionBehavior.RunAway:
                {
                    var direction = transform.position - _gameScene.Player.position;
                    _npcMovement.SetDirection(direction);
                    break;
                }
                case NpcReactionBehavior.Follow:
                {
                    var direction =  _gameScene.Player.position - transform.position;
                    _npcMovement.SetDirection(direction);
                    break;
                }
                case NpcReactionBehavior.Die:
                {
                    Destroy(gameObject);
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}