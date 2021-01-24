using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GState_MoveYourPiece : IState
{
    private Board _board;
    private Commander _commander;
    private Piece _selectedPiece;
    private PiecePool _pool;

    public GState_MoveYourPiece(Board board, Commander commander, PiecePool piecePool)
    {
        _board = board;
        _commander = commander;
        _pool = piecePool;
    }

    public void OnEnter()
    {
        SelectedPieceOnEnter();
        BoardSquare.SquareClicked += MoveSelected;
    }

    public void SelectedPieceOnEnter()
    {
        _selectedPiece = _board.lastPlacedPiece;
    }

    public void OnExit()
    {
        BoardSquare.SquareClicked -= MoveSelected;
    }

    public void Tick()
    {
        
    }

    // Originally i was considering the ability to click to select pieces, deselect and move. 
    // However to keep the scope down for a personal project. The last piece placed is selected.
    public void MoveSelected(BoardSquare boardSquare, int xBoardPos, int zBoardPos)
    {
        if(boardSquare.CurrentPiece != _selectedPiece && !boardSquare.HasPiece)
        {
            _commander.Command(_pool,_board, boardSquare, _selectedPiece, CommandType.Move);
        }
    }



}
