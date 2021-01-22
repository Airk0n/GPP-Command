using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_MovePiece : ICommand
{
    private BoardSquare _fromSquare;
    private BoardSquare _currentSquare;
    private Piece _piece;
    private int PieceID;
    public CommandType type => CommandType.Move;
    public Command_MovePiece(Piece piece, BoardSquare boardSquare)
    {
        _piece = piece;
        _fromSquare = _piece.CurrentSquare;
        _currentSquare = boardSquare;

    }
    public void Execute()
    {
        Piece.MovePieceToSquare(_piece, _currentSquare);
        _fromSquare.ApplyPiece(null);
        _currentSquare.ApplyPiece(_piece);
        _piece.CurrentSquare = _currentSquare;
    }

    public void Undo()
    {
        Piece.MovePieceToSquare(_piece, _fromSquare);
        _fromSquare.ApplyPiece(_piece);
        _currentSquare.ApplyPiece(null);
        _piece.CurrentSquare = _fromSquare;
    }
    private BoardSquare _previousSquare;


}
