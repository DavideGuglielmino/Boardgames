using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    private Board<Tile> board;
    private Pawn pawn = null;

    public void SetGrid(Board<Tile> board)
    {
        this.board = board;
    }

    public void SetPawn(Pawn pawn)
    {
        this.pawn = pawn;
    }

    public Pawn GetPawn()
    {
        return pawn;
    }
}