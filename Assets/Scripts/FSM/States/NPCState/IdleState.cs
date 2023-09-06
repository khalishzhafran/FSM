using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private NPC npc;

    public IdleState(Character character, StateMachine stateMachine, string animBoolName) : base(character, stateMachine, animBoolName)
    {
        npc = (NPC)character;
    }

    public override void Enter()
    {
        base.Enter();

        npc.SpriteRenderer.color = Color.white;
    }

    public override void Update()
    {
        base.Update();

        if (npc.HasTarget())
        {
            stateMachine.ChangeState(npc.ChaseState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
