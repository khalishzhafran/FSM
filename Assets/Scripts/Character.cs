using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[DisallowMultipleComponent]
public class Character : MonoBehaviour
{
    public Animator Animator { get; private set; }
    public Rigidbody2D Rb { get; private set; }
    public StateMachine StateMachine { get; protected set; }

    public float MovementSpeed = 5f;
    [Range(0, 0.9f)]
    [SerializeField] protected float movementSpeedMultiplier = 0.9f;
    [SerializeField] protected float slidingTime = 0.1f;

    protected virtual void Awake()
    {
        Animator = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();

        StateMachine = new StateMachine();
    }

    protected virtual void Update()
    {
        StateMachine.CurrentState?.Update();
    }

    public void ResetVelocity()
    {
        StartCoroutine(ResetVelocityCoroutine());
    }

    private IEnumerator ResetVelocityCoroutine()
    {
        while (Rb.velocity != Vector2.zero)
        {
            Rb.velocity = Rb.velocity * movementSpeedMultiplier;
            yield return new WaitForSeconds(slidingTime);
        }
    }
}
