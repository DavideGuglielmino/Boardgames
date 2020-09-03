using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBoard", menuName = "Data/Board Games/Rules/Board")]
public class BoardData : ScriptableObject
{
    public int rows;
    public int columns;
    [Space]
    public Sprite tileTexture;
    public Sprite pawnTexture;
}