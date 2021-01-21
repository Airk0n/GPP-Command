using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_PlacePiece : ICommand
{
    private Board _board;
    private BoardSquare _boardSquare;
    private Piece _piece;
    public CommandType type = CommandType.Place;


    public Command_PlacePiece(Board board, BoardSquare boardSquare, Piece piece)
    {
        this._board = board;
        this._boardSquare = boardSquare;
        this._piece = piece;
    }

    public void Execute()
    {
        this._board.PlacePiece(this._boardSquare, this._piece);
    }

    public void Undo()
    {
        this._boardSquare.DestroyAndNullMyPiece();
    }
}
