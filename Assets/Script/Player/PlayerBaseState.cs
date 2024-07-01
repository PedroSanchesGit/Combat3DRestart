using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class que permite aceder à maquina de estados do Player.
/// </summary>
public abstract class PlayerBaseState : State
{
    //protected - Apenas classes que herdam PlayerBaseState conseguem aceder a esta variável
    protected PlayerStateMachine stateMachine;

    /// <summary>
    /// Construtor da classe
    /// </summary>
    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    ///<summary>
    /// Método que movimenta o jogador com física
    /// </summary>
    protected void Move(Vector3 move, float deltaTime)
    {
        //Usar stateMachine.Controller para que fazer uso dos Colliders. Assim o jogador não poderá atravessar objectos.
        stateMachine.Controller.Move((move + stateMachine.ForceReceiver.Movement) * deltaTime);
    }
}
