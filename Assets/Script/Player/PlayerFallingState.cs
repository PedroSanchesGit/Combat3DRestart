using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class que gera um estado do Player - 
/// </summary>
public class PlayerFallingState : PlayerBaseState
{
    private const string FallString = "Fall";

    private const float CrossfadeDuration = 0.1f;

    private Vector3 momentum;

    /// <summary>
    /// Construtor que chama o construtor definido na class "PlayerBaseState"
    /// </summary>
    /// <param name="stateMachine"></param>
    public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        momentum = stateMachine.Controller.velocity;
        momentum.y = 0;
        stateMachine.Animator.CrossFadeInFixedTime(FallString, CrossfadeDuration);
    }

    public override void Tick(float deltaTime)
    {

        Move(momentum, deltaTime);

        if (stateMachine.Controller.isGrounded)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }

    }

    public override void Exit()
    {

    }



}
