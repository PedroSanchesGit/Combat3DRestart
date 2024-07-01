using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class que gera um estado do Player - 
/// </summary>
public class PlayerJumpingState : PlayerBaseState
{
    private const string JumpString = "Jump";

    private Vector3 momentum;

    private const float CrossfadeDuration = 0.1f;

    /// <summary>
    /// Construtor que chama o construtor definido na class "PlayerBaseState"
    /// </summary>
    /// <param name="stateMachine"></param>
    public PlayerJumpingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.ForceReceiver.Jump(stateMachine.JumpForce);

        //Mantém a velocidade no momento que estamos a começar a saltar
        momentum = stateMachine.Controller.velocity;
        momentum.y = 0; 

        stateMachine.Animator.CrossFadeInFixedTime(JumpString, CrossfadeDuration);
    }

    public override void Tick(float deltaTime)
    {

        Move(momentum, deltaTime);

        if (stateMachine.Controller.velocity.y <= 0)
        {
            stateMachine.SwitchState(new PlayerFallingState(stateMachine));
        }
        
    }

    public override void Exit()
    {

    }


}
