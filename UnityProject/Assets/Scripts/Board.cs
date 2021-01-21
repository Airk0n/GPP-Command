using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class Board : MonoBehaviour
{
    public int XLength;
    public int ZLength;
	private List<Piece> pieceStorage = new List<Piece>();
	public BoardSquare[,] Spaces { get; set; }
	private List<BoardSquare> boardSquareStorage = new List<BoardSquare>();

	private GameObject PiecesGroup;

	public void Start()
	{
		PiecesGroup = new GameObject("PiecesGroup");
	}
	public void ClearBoard()
	{
		foreach (Piece piece in pieceStorage)
		{
			Destroy(piece.gameObject);
			Destroy(piece);
		}

		pieceStorage.Clear();
		foreach (BoardSquare boardSquare in boardSquareStorage)
		{
			Destroy(boardSquare.gameObject);
			Destroy(boardSquare);
		}

		boardSquareStorage.Clear();
	}

	public void SetSpace(int x, int z)
    {
        this.Spaces = new BoardSquare[x, z];
    }

	public void InstantiateSpaces(int xBoardLength, int xBoardSpacing, int zBoardLength, int zBoardSpacing, BoardSquare blackSquarePrefab, BoardSquare whiteSquarePrefab)
	{
		for (int x = 0; x < xBoardLength; x++)
		{
			for (int z = 0; z < zBoardLength; z++)
			{
				BoardSquare newSquare = this.Spaces[x, z] = Instantiate((z % 2) - (x % 2) == 0 ? blackSquarePrefab : whiteSquarePrefab, new Vector3(x * xBoardSpacing, 0, z * zBoardSpacing), Quaternion.identity, this.transform);
				newSquare.Initialize(this, x, z);
				boardSquareStorage.Add(newSquare);
			}
		}
	}
	public void PlacePiece(BoardSquare boardSquare, Piece piece)
	{
		if (boardSquare.HasPiece)
			return;

		Piece newPiece = Instantiate(piece, new Vector3(boardSquare.transform.position.x, 0f, boardSquare.transform.position.z), Quaternion.identity);
		newPiece.transform.parent = PiecesGroup.transform;
		boardSquare.ApplyPiece(newPiece);
		pieceStorage.Add(newPiece);
	}
}