using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GState_InitialiseBoard : IState
{
    public bool BoardReady;

    private Board _board;
    private BoardSquare _blackPiece;
    private BoardSquare _whitePiece;

    public GState_InitialiseBoard(Board board, BoardSquare blackPiece, BoardSquare whitePiece)
    {
        _board = board;
        _blackPiece = blackPiece;
        _whitePiece = whitePiece;
    }
    public void OnEnter()
    {
        BoardReady = false;

        _board.ClearBoard();
        _board.SetSpace(_board.XLength, _board.ZLength);
        _board.InstantiateSpaces(_board.XLength,1, _board.ZLength, 1, _blackPiece, _whitePiece);

    }

    public void OnExit()
    {
        
    }

    public void Tick()
    {
        BoardReady = true;
    }


}
