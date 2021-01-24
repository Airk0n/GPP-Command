using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_PlacePiece : ICommand
{
    /* Purpose :
     * To find a piece from the piece pool, remember which piece it is, and place it on the board. Undo is just hiding it.
     */
    private Board _board;
    private BoardSquare _boardSquare;
    private Piece _piece;
    private PiecePool _piecePool;
    private int _pieceID;
    private bool _IDSet;
    CommandType ICommand.type => CommandType.Place;

    public Command_PlacePiece(PiecePool piecePool,Board board,BoardSquare boardSquare)
    {
        _piecePool = piecePool;
        _board = board;
        _boardSquare = boardSquare;


    }

    public void Execute()
    {
        if(_IDSet)
        {
            _board.PlacePiece(_boardSquare, _piece, _pieceID);
            _boardSquare.CurrentPiece.CurrentSquare = _boardSquare;
        }
        else
        {
            _pieceID = _piecePool.GetNextKey();
            _piece = _piecePool.FindPiece(_pieceID);
            _board.PlacePiece(_boardSquare, _piece, _pieceID);
            _boardSquare.CurrentPiece.CurrentSquare = _boardSquare;
            _IDSet = true;
        }

    }

    public void Undo()
    {
        _piece.gameObject.SetActive(false);
        _boardSquare.NullMyPiece();

    }
}
