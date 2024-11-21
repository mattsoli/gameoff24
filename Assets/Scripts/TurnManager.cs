using UnityEngine;

public enum TurnState
{
    Player,
    AI
}

public class TurnManager : MonoBehaviour
{
    public TurnState currentTurn;

    void Start()
    {
        currentTurn = TurnState.Player;
    }

    void Update()
    {
        if (currentTurn == TurnState.Player)
        {
            // Debug.Log("Turno del giocatore: scegli l'area da attaccare.");
            // Logica per l'attacco del giocatore
            // PlayerAttack();
        }
        else if (currentTurn == TurnState.AI)
        {
            Debug.Log("Turno dell'IA: difesa.");
            // Logica per la difesa dell'IA (da implementare)
            AIDefense();
        }
    }

    void PlayerAttack()
    {
        // Implementare la logica di attacco
        currentTurn = TurnState.AI;
    }

    void AIDefense()
    {
        // Implementare la logica di difesa dell'IA
        currentTurn = TurnState.Player;
    }
}