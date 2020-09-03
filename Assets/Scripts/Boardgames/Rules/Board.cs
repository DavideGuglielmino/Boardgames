using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board<T>
{
    public BoardData boardData;
    public Vector3 originPosition;
    public float tileSize;
    public T[,] boardMatrix;

    public Board(BoardData boardData, Vector3 originPosition, float tileSize, T[,] boardMatrix)
    {
        this.boardData = boardData;
        this.originPosition = originPosition;
        this.tileSize = tileSize;
        this.boardMatrix = boardMatrix;
    }

    public float GetTileSize()
    {
        return tileSize;
    }

    private Vector3 vectorOneWithOutY = new Vector3(1, 0, 1);
    //Ottiene la posizione delle singole celle
    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, z, 0) * tileSize + vectorOneWithOutY * tileSize * 0.5f + originPosition;
    }

    //è Santa, NON TOCCATELA 
    public Vector3 GetWorldPositionNoOrigin(int x, int z)
    {
        return new Vector3(x, z, 0) * tileSize;
    }

    //Ottieneze la x e la z dalla posizione del mondo
    //Out serve per far tornare un valore anche se la funzione è void
    public void GetXZ(Vector3 worldPosition, out int i, out int j)
    {
        //Ritorna l'intero più grande vicino ad f 
        //f parametro della funzione
        i = Mathf.FloorToInt((worldPosition.x - originPosition.x) / tileSize);
        j = Mathf.FloorToInt((worldPosition.y - originPosition.y) / tileSize);
    }

    public void SetMyBoardObject(int x, int z, T value)
    {
        if (x >= 0 && z >= 0 && x < boardData.columns && z < boardData.rows)
        {
            boardMatrix[x, z] = value;
        }
    }

    public void SetMyBoardObject(Vector3 worldPosition, T value)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        SetMyBoardObject(x, z, value);
    }

    public T GetMyBoardObject(int i, int j)
    {
        if (i >= 0 && j >= 0 && i < boardData.columns && j < boardData.rows)
        {
            return boardMatrix[i, j];
        }
        else
        {
            return default(T);
        }
    }

    public T GetMyBoardObject(Vector3 worldPosition)
    {
        int i, j;
        GetXZ(worldPosition, out i, out j);
        return GetMyBoardObject(i, j);
    }

    public int GetRows()
    {
        return boardData.rows;
    }

    public int GetColumns()
    {
        return boardData.columns;
    }

    public Vector3 GetOriginPosition()
    {
        return originPosition;
    }

    public T[,] GetGridMatrix()
    {
        return boardMatrix;
    }
}