using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnsBowl : Singleton<PawnsBowl>
{
    private Pawn currentPawn = null;

    private void Start()
    {
        PlayerController.Instance.OnPawnPlaced += OnPawnPlaced;
        InitializeBowl();
    }

    public void SetPawnSelected(Pawn newPawn)
    {
        currentPawn = newPawn;
    }

    public Pawn GetPawnPicked()
    {
        return currentPawn;
    }

    // Go Rules
    private Player currentPlayer;
    private Pawn blackPawn;
    private Pawn whitePawn;

    private void InitializeBowl()
    {
        blackPawn = Resources.Load<Pawn>("Go/BlackPawn");
        whitePawn = Resources.Load<Pawn>("Go/WhitePawn");
    }

    private void OnPawnPlaced()
    {
        currentPawn = null;

        // Go Rules
        switch (currentPlayer)
        {
            case Player.A:
                currentPlayer = Player.B;
                SetPawnSelected(whitePawn);
                break;
            case Player.B:
                currentPlayer = Player.A;
                SetPawnSelected(blackPawn);
                break;
            default:
                Debug.Log("Error, shouldn't have more than two players");
                break;
        }
    }
}

public enum Player
{
    A,
    B
}