using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class ChaseState : State
{
    private NPC npc;

    public ChaseState(Character character, StateMachine stateMachine, string animBoolName) : base(character, stateMachine, animBoolName)
    {
        npc = (NPC)character;
    }

    public override void Enter()
    {
        base.Enter();

        npc.SpriteRenderer.color = Color.red;
    }

    public override void Update()
    {
        base.Update();

        if (!npc.HasTarget())
        {
            stateMachine.ChangeState(npc.IdleState);
            return;
        }

        character.Rb.velocity = (npc.Target.position - npc.transform.position).normalized * character.MovementSpeed;

        if (npc.TargetInAttackRange())
        {
            stateMachine.ChangeState(npc.AttackState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        character.ResetVelocity();
    }
}
