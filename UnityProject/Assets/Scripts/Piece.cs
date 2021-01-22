using UnityEngine;

public class Piece : MonoBehaviour
{
	private Renderer modelMaterial;

	private Vector3 startPosition;
	private Vector3 endPosition;
	private float speed;
	public bool isMoving;
	private float interpolateValue;
	public BoardSquare CurrentSquare;


	private void Awake()
	{
		modelMaterial = GetComponentInChildren<Renderer>();
	}

	public void Update()
	{
		if (isMoving)
		{
			if (Vector3.Distance(this.transform.position, endPosition) > 0.01)
			{
				interpolateValue += Time.deltaTime * speed;
				var easing = Easing.Quartic.InOut(interpolateValue);
				//Debug.Log($"interpolateValue = {interpolateValue} Easing = {easing}");
				this.transform.position = Vector3.Lerp(startPosition, endPosition, easing);
			}
			else
			{
				this.transform.position = endPosition;
				isMoving = false;
				onPieceMoved?.Invoke();
			}

		}
	}

	internal static void MovePieceToSquare(Piece piece, BoardSquare boardSquare)
	{
		piece.interpolateValue = 0;
		piece.startPosition = piece.transform.position;
		piece.endPosition = boardSquare.transform.position;
		piece.speed = 2f;
		piece.isMoving = true;
	}

	public delegate void PieceMoved();
	public static event PieceMoved onPieceMoved;

	internal void SetHighlight()
	{
		//modelMaterial.material.SetColor("Color_3AFA6100", this.Theme.SelectedHighlightColour);
	}

	internal void ClearHighlight()
	{
		modelMaterial.material.SetColor("Color_3AFA6100", new Color(0, 0, 0, 0));
	}
}