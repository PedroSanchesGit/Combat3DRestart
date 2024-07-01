using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Construção da classe StateMachine que permite controlar a máquina de estados para fazer a transição entre os mesmos
/// Abstract - impede que haja a possibilidade de declarar uma variável do tipo State, podendo apenas ser herdada a sua funcionalidade
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
        //Time.deltaTime - variável pré-definida do Unity que contem a diferença temporal entre o último frame e o atual
        //O ponto de interrogação abaixo faz uma verificação se a variável 'currentState' é nula antes de tentar chamar o método 'Tick()'. Semelhante a um if(currentState != null) { }
        currentState?.Tick(Time.deltaTime);
    }

    /// <summary>
    /// Método que permite udança entre o estado atual e um novo estado passado como parâmetro
    /// </summary>
    /// <param name="newState">Novo estado para passar a ser o estado atual</param>
    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
        
    }
}
