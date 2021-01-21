using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GState_PlaceYourPiece : IState
{
    private Board _board;
    private Piece _piece;
    private Commander _commander;

    public GState_PlaceYourPiece(Board board, Piece piece, Commander commander)
    {
        _board = board;
        _piece = piece;
        _commander = commander;
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
            _commander.PlacePiece(boardSquare, _piece);
        }				



				

	}

}
