using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Character
{
    public IdleState IdleState { get; private set; }
    public ChaseState ChaseState { get; private set; }
    public AttackState AttackState { get; private set; }

    public SpriteRenderer SpriteRenderer { get; private set; }

    public Transform Target { get; set; }

    [SerializeField] private float chaseRadius = 1f;
    [SerializeField] private float attackRadius = 0.5f;
    [SerializeField] private GameObject bulletPrefab;
    public float ShootCooldown = 0.3f;

    protected override void Awake()
    {
        base.Awake();

        SpriteRenderer = GetComponent<SpriteRenderer>();

        IdleState = new IdleState(this, StateMachine, "idle");
        ChaseState = new ChaseState(this, StateMachine, "chase");
        AttackState = new AttackState(this, StateMachine, "attack");

        StateMachine.Initialize(IdleState);
    }

    protected override void Update()
    {
        base.Update();

        CheckPlayerInChaseRadius();
    }

    private void CheckPlayerInChaseRadius()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, chaseRadius);

        foreach (Collider2D target in targets)
        {
            if (target.TryGetComponent(out Player player))
            {
                Target = player.transform;
                return;
            }
        }

        Target = null;
    }

    public bool HasTarget()
    {
        return Target != null;
    }

    public bool TargetInAttackRange()
    {
        return Vector2.Distance(transform.position, Target.position) <= attackRadius;
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.right = Target.position - transform.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
