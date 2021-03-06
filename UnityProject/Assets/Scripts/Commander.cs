﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commander : MonoBehaviour
{

    //Holds a record of actions.
    //Holds methods of moving back and forth through actions.

    public Dictionary<int, ICommand> CommandSequence = new Dictionary<int, ICommand>();
    [SerializeField] private int _currentStep = 0;
    [SerializeField] private int _undoStep = 0;
    [SerializeField] private int commandSequenceLength; // for debug
    [SerializeField] private bool _upToDate = true;
    [SerializeField] private UICommandList _uiCommandList;

    private void Start()
    {
        UpdateSequence();
    }

    private void Update()
    {
        commandSequenceLength = CommandSequence.Count;
        _uiCommandList.CommanderStatus(_currentStep, _undoStep, _upToDate);
    }

    public void UpdateSequence()
    {
        _undoStep = _currentStep;
        _upToDate = true;
    }

    public void Undo()
    {
        if(_currentStep == 0 || _undoStep == 0)
        {
            return;
        }

        if (_currentStep == _undoStep)
        {
            CommandSequence[_currentStep-1].Undo();
        } 
        else
        {
            CommandSequence[_undoStep-1].Undo();
        }

        if(_undoStep > 0)
        {
            _undoStep--;
        }
        _upToDate = false;
    }

    public void Redo()
    {
        if(_undoStep == _currentStep)
        {
            return;
        }

        CommandSequence[_undoStep].Execute();
        _undoStep++;

        if(_undoStep != _currentStep)
        {
            _upToDate = false;
        }

        if(_undoStep == _currentStep)
        {
            UpdateSequence();
        }


    }

    public void Command(PiecePool piecePool, Board board, BoardSquare boardSquare, Piece piece, CommandType type)
    {
        ICommand commandToExecute = new Command_MovePiece(piece, boardSquare); // just a default value
        switch (type)
        {
            case CommandType.Move :
                commandToExecute = new Command_MovePiece(piece, boardSquare);
                break;
            case CommandType.Place:
                commandToExecute = new Command_PlacePiece(piecePool,board,boardSquare);
                break;
        }


        if(_upToDate) // UpToDate means we are not in an undo state.
        {
            CommandSequence.Add(_currentStep, commandToExecute);
            commandToExecute.Execute();
            _uiCommandList.AddToList(commandToExecute, this);
            _currentStep++;
            UpdateSequence();
        }
        else  // If we are in an Undo state then we need to clear the undo history before moving on.
        {
            ClearSequenceAfterUndoStep();
            CommandSequence.Add(_undoStep, commandToExecute);
            commandToExecute.Execute();
            _uiCommandList.AddToList(commandToExecute, this);
            _currentStep = _undoStep;
            _currentStep++;
            UpdateSequence();
        }

    }
    public void ClearSequenceAfterUndoStep()
    {
        _uiCommandList.NewPath(_undoStep);
        for (int i = _undoStep; i <= _currentStep; i++)
        {
            CommandSequence.Remove(i);
        }
    }

    public void JumpTo(int undoStep)
    {
        int difference = _undoStep - undoStep;
        if(difference == 0)
        {
            return;
        }

        if(difference < 0)
        {
            int diffAsPositiveNumber = Mathf.Abs(difference);
            for (int i = 0; i < diffAsPositiveNumber; i++)
            {
                Redo();
            }
        }
        if (difference > 0)
        {
            for (int i = 0; i < difference; i++)
            {
                Undo();
            }
        }


    }



}
