using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private float horizontalInput;
    private float verticalInput;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();

        HandleInput();
        HandleMovement();
    }

    private void HandleInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void HandleMovement()
    {
        Rb.velocity = new Vector2(horizontalInput * MovementSpeed, verticalInput * MovementSpeed);
    }
}
