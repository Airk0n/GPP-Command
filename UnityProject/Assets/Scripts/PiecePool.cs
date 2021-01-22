using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePool : MonoBehaviour
{
    [SerializeField] private Piece _piecePrefab;
    private Dictionary<int, Piece> _piecePool = new Dictionary<int, Piece>();
    [SerializeField] private int _piecePoolLen;

    private void Update()
    {
        _piecePoolLen = _piecePool.Count;
    }

    public int GetNextKey()
    {
        return _piecePool.Count;
    }

    public Piece FindPiece(int key)
    {
        if(_piecePool.ContainsKey(key))
        {
            return _piecePool[key];
        }
        if (!_piecePool.ContainsKey(key))
        {
            Piece newPiece = Instantiate(_piecePrefab, Vector3.zero, Quaternion.identity);
            _piecePool.Add(key, newPiece);
            return newPiece;
        }
        return null;
    }

    private void AddPieceToPool(int key)
    {

    }

    public void ReturnPieceToPool(int key)
    {
        _piecePool[key].gameObject.SetActive(false);
    }
}
