using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Constru��o da classe StateMachine que permite controlar a m�quina de estados para fazer a transi��o entre os mesmos
/// Abstract - impede que haja a possibilidade de declarar uma vari�vel do tipo State, podendo apenas ser herdada a sua funcionalidade
/// </summary>
public abstract class StateMachine : MonoBehaviour
{
    //State em que nos encontramos atualmente
    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Time.deltaTime - vari�vel pr�-definida do Unity que contem a diferen�a temporal entre o �ltimo frame e o atual
        //O ponto de interroga��o abaixo faz uma verifica��o se a vari�vel 'currentState' � nula antes de tentar chamar o m�todo 'Tick()'. Semelhante a um if(currentState != null) { }
        currentState?.Tick(Time.deltaTime);
    }

    /// <summary>
    /// M�todo que permite udan�a entre o estado atual e um novo estado passado como par�metro
    /// </summary>
    /// <param name="newState">Novo estado para passar a ser o estado atual</param>
    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
        
    }
}
