using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBoard : Singleton<DrawBoard>
{
    public BoardData board;
    public Board<Tile> newBoard;
    [Space]
    public Vector3 startingPosition;
    public float tileOffset;
    [Space][Header("Debug")]
    public SpriteRenderer example;

    private void Start()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        Transform transform1 = transform;
        example.sprite = board.tileTexture;
        tileOffset = example.size.x;
        Vector3 position = startingPosition;
        Quaternion rotation = Quaternion.Euler(0, 0, 0);

        Tile[,] boardMatrix = new Tile[board.rows, board.columns];
        Board<Tile> newBoard = new Board<Tile>(board, transform1.position, tileOffset, boardMatrix);
        for (int i = 0; i < board.rows; ++i)
        {
            for(int j = 0; j < board.columns; ++j)
            {
                // Logic
                boardMatrix[i, j] = new Tile();
                boardMatrix[i, j].SetGrid(newBoard);
                newBoard.SetMyBoardObject(i, j, boardMatrix[i, j]);
                // Visuals
                Instantiate(example, position, rotation, transform1);
                position.y += tileOffset;
            }

            position.x += tileOffset;
            position.y = startingPosition.y;
        }
    }
}