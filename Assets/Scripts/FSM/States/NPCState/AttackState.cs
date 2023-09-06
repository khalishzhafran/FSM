using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private NPC npc;
    private float shootTimer;

    public AttackState(Character character, StateMachine stateMachine, string animBoolName) : base(character, stateMachine, animBoolName)
    {
        npc = (NPC)character;
    }

    public override void Enter()
    {
        base.Enter();

        npc.SpriteRenderer.color = Color.blue;

        shootTimer = 0;
    }

    public override void Update()
    {
        base.Update();

        if (!npc.HasTarget())
        {
            stateMachine.ChangeState(npc.IdleState);
            return;
        }

        if (!npc.TargetInAttackRange())
        {
            stateMachine.ChangeState(npc.ChaseState);
            return;
        }

        shootTimer += Time.deltaTime;

        if (character.Rb.velocity == Vector2.zero && shootTimer >= npc.ShootCooldown)
        {
            npc.Shoot();
            shootTimer = 0;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
