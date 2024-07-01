using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class que gera um estado do Player - 
/// </summary>
public class PlayerFreeLookState : PlayerBaseState
{
    private const string FreeLookSpeedString = "FreeLookSpeed";
    //AnimatorDampTime terá o valor de Damping que se trata do atrito que o objeto encontrará ao ser puxado em direção ao seu alvo
    private const float AnimatorDampTime = 0.1f;

    /// <summary>
    /// Construtor que chama o construtor definido na class "PlayerBaseState"
    /// </summary>
    /// <param name="stateMachine"></param>
    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.JumpEvent += OnJump;
    }

    public override void Tick(float deltaTime)
    {

        Vector3 movement = CalculateMovement();

        //Movimental jogador
        Move(movement * stateMachine.FreeLookMovementSpeed, deltaTime);

        //Se não houver input de momento, sai do método
        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            //Variável criada na BlendTree no Animator para definir que a animação do Player deve ser a Idle
            stateMachine.Animator.SetFloat(FreeLookSpeedString, 0, 0.1f, deltaTime);
            return;
        }

        //Variável criada na BlendTree no Animator para definir que a animação do Player deve ser a Running
        stateMachine.Animator.SetFloat(FreeLookSpeedString, 0.5f, 0.1f, deltaTime);

        FaceMovementDirection(movement, deltaTime);
        
    }

    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= OnJump;
    }

    /// <summary>
    /// Método para calcular movimento em conformidade com a posição da câmara atual e com os inputs do jogador
    /// </summary>
    /// <returns>Vector3 com a posição final</returns>
    private Vector3 CalculateMovement()
    {
        //Captura da posição da câmara utilizando o vector "forward" e o vector "right" que permitirão definir o movimento da personagem consoante a posição da câmara no mundo de jogo
        Vector3 forward = new Vector3(stateMachine.MainCamera.transform.forward.x, 0f, stateMachine.MainCamera.transform.forward.z);
        Vector3 right = new Vector3(stateMachine.MainCamera.transform.right.x, 0, stateMachine.MainCamera.transform.right.z);

        forward.Normalize();
        right.Normalize();

        return (forward * stateMachine.InputReader.MovementValue.y) + (right * stateMachine.InputReader.MovementValue.x);
        
    }

    /// <summary>
    /// Método que redireciona o player na direção para a qual a câmara está apontada
    /// </summary>
    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        //Garante que o jogador irá rodar na direção para a qual se está a dirigir
        stateMachine.transform.rotation = 
            Quaternion.Lerp(stateMachine.transform.rotation,
            Quaternion.LookRotation(movement),
            deltaTime * stateMachine.RotationDampValue);
    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerJumpingState(stateMachine));
    }

}
