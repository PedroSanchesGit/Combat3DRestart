using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Constru��o da classe State que permitir� atribuir as funcionalidades de uma StateMachine aos v�rios estados que ser�o criados
/// Abstract - impede que haja a possibilidade de declarar uma vari�vel do tipo State, podendo apenas ser herdada a sua funcionalidade
/// </summary>
public abstract class State
{
    //M�todo que � executado quando entramos no novo estado (Exemplo: Quando uma personagem come�a a correr entra no State "Run")
    public abstract void Enter();

    //M�todo que � executado em loop enquanto estamos dentro de um estado (Exemplo: Enquanto estamos a correr devemos calcular a velocidade a que a personagem deve correr)
    public abstract void Tick(float deltaTime);

    //M�todo executado quando sa�dos de um determinado estado (Exemplo: Quando a personagem deixa de correr e se coloca em estado IDLE)
    public abstract void Exit();
}
