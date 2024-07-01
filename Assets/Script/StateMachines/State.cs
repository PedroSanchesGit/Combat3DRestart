using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Construção da classe State que permitirá atribuir as funcionalidades de uma StateMachine aos vários estados que serão criados
/// Abstract - impede que haja a possibilidade de declarar uma variável do tipo State, podendo apenas ser herdada a sua funcionalidade
/// </summary>
public abstract class State
{
    //Método que é executado quando entramos no novo estado (Exemplo: Quando uma personagem começa a correr entra no State "Run")
    public abstract void Enter();

    //Método que é executado em loop enquanto estamos dentro de um estado (Exemplo: Enquanto estamos a correr devemos calcular a velocidade a que a personagem deve correr)
    public abstract void Tick(float deltaTime);

    //Método executado quando saídos de um determinado estado (Exemplo: Quando a personagem deixa de correr e se coloca em estado IDLE)
    public abstract void Exit();
}
