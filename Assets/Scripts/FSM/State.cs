using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Character character;
    protected StateMachine stateMachine;
    protected string animBoolName;

    public State(Character character, StateMachine stateMachine, string animBoolName)
    {
        this.character = character;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        character.Animator.SetBool(animBoolName, true);
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
        character.Animator.SetBool(animBoolName, false);
    }
}
