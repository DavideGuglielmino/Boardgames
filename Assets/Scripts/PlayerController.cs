using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    private LayerMask boardLayerMask;

    public delegate void PawnPlaced();
    public event PawnPlaced OnPawnPlaced;

    void Start()
    {
        boardLayerMask = LayerMask.NameToLayer("Board");
    }

    private void OnSelectMain()
    {
        Pawn pawnToPlace = PawnsBowl.Instance.GetPawnPicked();
        if (pawnToPlace == null)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (Physics.Raycast(ray, out RaycastHit hit, 20f, boardLayerMask))
        {
            Tile tile = hit.transform.GetComponent<DrawBoard>().newBoard.GetMyBoardObject(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
            if (tile == null)
                return;

            Pawn pawn = tile.GetPawn();
            if (pawn == null) // TODO: this is already a Go Rule
                return;

            tile.SetPawn(pawnToPlace);
            // TODO: Instantiate Pawn here
            OnPawnPlaced?.Invoke();
        }
    }
}