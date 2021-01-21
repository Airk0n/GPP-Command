using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{

    //Holds a record of actions.
    //Holds methods of moving back and forth through actions.

    private Dictionary<int, ICommand> commandSequence = new Dictionary<int, ICommand>();
    [SerializeField] private int currentStep = 0;
    [SerializeField] private int undoStep = 0;
    [SerializeField] private int commandSequenceLength;
    [SerializeField] private Board _board;
    [SerializeField] private bool _upToDate = true;

    public void UpToDate()
    {
        undoStep = currentStep;
        _upToDate = true;

        // Here I clear the undo log after this point.
        if(commandSequence.Count > (currentStep-1))
        {
            for (int i = currentStep; i < commandSequence.Count; i++)
            {
                commandSequence.Remove(i);
            }
        }
        commandSequenceLength = commandSequence.Count;

    }

    public void ClearSequenceAfterCurrentStep()
    {
        if (commandSequence.Count > (currentStep - 1))
        {
            for (int i = currentStep; i < commandSequence.Count; i++)
            {
                commandSequence.Remove(i);
            }
        }
    }

    public void Undo()
    {
        if(currentStep == 0 || undoStep == 0)
        {
            return;
        }

        if (currentStep == undoStep)
        {
            commandSequence[currentStep-1].Undo();
        } 
        else
        {
            commandSequence[undoStep-1].Undo();
        }

        if(undoStep > 0)
        {
            undoStep--;
        }
        _upToDate = false;
    }

    public void Redo()
    {
        if(undoStep == currentStep)
        {
            return;
        }

        commandSequence[undoStep].Execute();
        undoStep++;
        _upToDate = false;
    }

    public void PlacePiece(BoardSquare boardSquare, Piece piece)
    {
        if(_upToDate)
        {
            var commandObject = new Command_PlacePiece(_board, boardSquare, piece);
            commandObject.Execute();
            commandSequence.Add(currentStep, commandObject);
            currentStep++;
            UpToDate();
        }
        else
        {
            currentStep = undoStep;
            ClearSequenceAfterCurrentStep();
            var commandObject = new Command_PlacePiece(_board, boardSquare, piece);
            commandObject.Execute();
            commandSequence.Add(currentStep, commandObject);
            currentStep++;
            UpToDate();
        }


    }



}
