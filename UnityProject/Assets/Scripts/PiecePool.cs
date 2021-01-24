using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePool : MonoBehaviour
{
    /*Purpose:
     * To manage and instaiate pieces as requested by the user. 
     * Each piece is given a unique key upon creation, this couples it to the specific command and allows the move command to access it correctly.
     * Currently the maximum pieces is 25 however if this bigger I would consider a different implementation to reduce memory usage.
     */
    [SerializeField] private Piece _piecePrefab;
    [SerializeField] private int _piecePoolLen;
    private Dictionary<int, Piece> _piecePool = new Dictionary<int, Piece>();

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

    public void ReturnPieceToPool(int key)
    {
        _piecePool[key].gameObject.SetActive(false);
    }
}
