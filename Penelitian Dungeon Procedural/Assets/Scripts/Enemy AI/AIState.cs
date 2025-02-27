using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIStateID
{
    TestingState,
    ChasePlayer,
    IdleState,
    AttackState,
    BlockingState,
    DeathState,
    PatrolState,
    FleeState,
    RoarState
}
public interface AIState
{
    AIStateID GetID();
    void Enter(AIAgent agent);
    void Update(AIAgent agent);
    void Exit(AIAgent agent);
}
