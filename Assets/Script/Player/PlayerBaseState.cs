using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class que permite aceder � maquina de estados do Player.
/// </summary>
public abstract class PlayerBaseState : State
{
    //protected - Apenas classes que herdam PlayerBaseState conseguem aceder a esta vari�vel
    protected PlayerStateMachine stateMachine;

    /// <summary>
    /// Construtor da classe
    /// </summary>
    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    ///<summary>
    /// M�todo que movimenta o jogador com f�sica
    /// </summary>
    protected void Move(Vector3 move, float deltaTime)
    {
        //Usar stateMachine.Controller para que fazer uso dos Colliders. Assim o jogador n�o poder� atravessar objectos.
        stateMachine.Controller.Move((move + stateMachine.ForceReceiver.Movement) * deltaTime);
    }
}
