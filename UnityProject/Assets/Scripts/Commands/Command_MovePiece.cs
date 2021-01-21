using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_MovePiece : ICommand
{
    public Command_MovePiece(Board board,BoardSquare moveFrom, BoardSquare moveTo)
    {
        _previousSquare = moveFrom;
    }
    public void Execute()
    {
        
    }

    public void Undo()
    {
        
    }
    private BoardSquare _previousSquare;
}
