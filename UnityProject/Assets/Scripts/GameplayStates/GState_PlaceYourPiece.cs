using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GState_PlaceYourPiece : IState
{
    private Board _board;
    private Piece _piece;
    private Commander _commander;
    private PiecePool _piecePool;

    public GState_PlaceYourPiece(Board board, Piece piece, Commander commander, PiecePool pool)
    {
        _board = board;
        _piece = piece;
        _commander = commander;
        _piecePool = pool;
    }
    public void OnEnter()
    {
		BoardSquare.SquareClicked += CreatePiece;
	}

    public void OnExit()
    {
		BoardSquare.SquareClicked -= CreatePiece;
	}

    public void Tick()
    {

    }

	public void CreatePiece(BoardSquare boardSquare, int xBoardPos, int zBoardPos)
	{

		if (boardSquare is null)
			return;

		if (boardSquare.HasPiece)
			Debug.Log("Square occupied already");
        else
        {
            _commander.Command(_piecePool,_board, boardSquare, _piece, CommandType.Place);
        }				

	}

}
