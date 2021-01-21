using System;

using UnityEngine;
using UnityEngine.EventSystems;

public class BoardSquare : MonoBehaviour, IPointerClickHandler
{

	/// <summary>
	/// The current piece (if any) that is currently on this board square.
	/// </summary>
	public Piece CurrentPiece { get; private set; }
	public int X;
	public int Z;

	private Board _board;

	/// <summary>
	/// Returns whether the board square currently has a piece
	/// </summary>
	public bool HasPiece => CurrentPiece != null;
	public void DestroyAndNullMyPiece()
    {
		Destroy(CurrentPiece.gameObject);
		Destroy(CurrentPiece);
		CurrentPiece = null;
    }

	/// <summary>
	/// Sets the current piece for this square
	/// </summary>
	/// <param name="piece"></param>
	internal void ApplyPiece(Piece piece) => CurrentPiece = piece;


	#region OnPointerClick Event

	public delegate void SquareClick(BoardSquare boardSquare, int xBoardPos, int zBoardPos);

	public static event SquareClick SquareClicked;

	public void OnPointerClick(PointerEventData eventData)
	{
		//Debug.Log($"X: {this.X}, Z: {this.Z}");
		SquareClicked?.Invoke(this, X, Z);
	}

	#endregion OnPointerClick Event

	internal void Initialize(Board board, int x, int z)
	{
		_board = board;
		X = x;
		Z = z;
	}
}