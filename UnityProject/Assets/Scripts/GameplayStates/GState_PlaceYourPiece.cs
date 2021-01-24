using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GState_PlaceYourPiece : IState
{
    /* Purpose: 
    * This state represents the player having selected the "place" tool, 
    * this class handles the behaviour associated with placing/creating pieces based on the square the user clicks on.
    */

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
		BoardSquare.SquareClicked += CreatePlacePiece;
	}

    public void OnExit()
    {
		BoardSquare.SquareClicked -= CreatePlacePiece;
	}

    public void Tick()
    {

    }

	public void CreatePlacePiece(BoardSquare boardSquare, int xBoardPos, int zBoardPos)
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
