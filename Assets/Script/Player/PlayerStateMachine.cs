using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class que atribuir� os estados ao Player
/// Como herdamos as caracter�sticas da Class "StateMachine", herdamos consequentemente tamb�m as caracter�sticas da class "MonoBehaviour"
/// </summary>
public class PlayerStateMachine : StateMachine
{
    //Permite o acesso � propriedade "InputReader" publicamente 
    [field: SerializeField]public InputReader InputReader { get; set; }
    [field: SerializeField]public CharacterController Controller { get; set; }
    [field: SerializeField] public Animator Animator { get; set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; set; }
    [field: SerializeField]public float FreeLookMovementSpeed { get; set; }
    [field: SerializeField]public float RotationDampValue { get; set; }
    [field: SerializeField]public float JumpForce { get; set; }

    public Camera MainCamera { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;

        //Atribui��o do estado TestState ao Player.
        SwitchState(new PlayerFreeLookState(this));
    }

}
