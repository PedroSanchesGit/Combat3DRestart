using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class que permite manipular os inputs dados pelo jogador
/// </summary>
public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    [field:SerializeField] public Vector2 MovementValue { get; private set; }

    //Defini��o de vari�veis Action para controlar os Events
    public event Action JumpEvent;
    public event Action DodgeEvent;


    private Controls controls;

    // Start is called before the first frame update
    void Start()
    {
        //Conex�o necess�ria para que consigamos controlar o que foi definido no "Input Actions" chamado "Controls"
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    void OnDestroy()
    {
        controls.Player.Disable();
    }

    /// <summary>
    /// Quando as teclas definidas em 'Controls' para o Jump forem clicadas, este m�todo ser� executado
    /// </summary>
    /// <param name="context">Cont�m a informa��o do input no bot�o/bot�es definido/os para este evento</param>
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            JumpEvent?.Invoke();
        }
    }

    /// <summary>
    /// Quando as teclas definidas em 'Controls' para o Dodge forem clicadas, este m�todo ser� executado
    /// </summary>
    /// <param name="context">Cont�m a informa��o do input no bot�o/bot�es definido/os para este evento</param>
    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DodgeEvent?.Invoke();
        }
    }

    /// <summary>
    /// Quando as teclas definidas em 'Controls' para o Movimento forem clicadas, este m�todo ser� executado
    /// </summary>
    /// <param name="context">Cont�m a informa��o do input no bot�o/bot�es definido/os para este evento</param>
    public void OnMove(InputAction.CallbackContext context)
    {
        //Movimento retorna-nos um vetor [x, y] = Vector2 que retorna a dire��o para a qual a personagem se ir� deslocar
        MovementValue = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Quando as teclas definidas em 'Controls' para o controlo da c�mara forem clicadas, este m�todo ser� executado
    /// </summary>
    /// <param name="context">Cont�m a informa��o do input no bot�o/bot�es definido/os para este evento</param>
    public void OnLook(InputAction.CallbackContext context)
    {
        //Ficar� vazio aqui. Qualquer controlo de c�mara ser� realizado diretamente nos componentes de Cinemachine
    }
}
