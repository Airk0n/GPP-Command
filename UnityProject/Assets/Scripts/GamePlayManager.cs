using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    /* Purpose: 
     * To contain and run the state machine. It feeds the states with what they need to 
     * manage what the player can interact with.
     */


    [SerializeField] private Board _board;
    [SerializeField] private BoardSquare _blackSquare;
    [SerializeField] private BoardSquare _whiteSqwuare;
    [SerializeField] private Piece _piece;
    [SerializeField] private Commander _commander;
    [SerializeField] private PiecePool _pool;

    private bool placeMove;
    private StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _board.GivePiece(_piece); // initialise the board by giving it access to the prefab.

        // States cached.
        var _initBoard = new GState_InitialiseBoard(_board, _blackSquare, _whiteSqwuare);
        var _placePhase = new GState_PlaceYourPiece(_board, _piece, _commander, _pool);
        var _movePhase = new GState_MoveYourPiece(_board, _commander, _pool);

        // Transitions between states with conditions.
        At(_initBoard, _placePhase, BoardInitialised());
        At(_placePhase, _movePhase, IntoMoveMode());
        At(_movePhase, _placePhase, IntoPlaceMode());

        // Default State
        _stateMachine.SetState(_initBoard);

        // Conditions for transitioning between states.
        Func<bool> BoardInitialised() => () => _initBoard.BoardReady = true;
        Func<bool> IntoMoveMode() => () => placeMove == true;
        Func<bool> IntoPlaceMode() => () => placeMove == false;

        // AT = add transition.
        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(from: to, to: from, condition);
    }
    
    public void PlaceMoveToggle(CommandType type)
    {
        // I'm using a bool because I know that i'm only implementing 2 commands, place and move.
        switch(type)
        {
            case CommandType.Move:
                placeMove = false;
                break;
            case CommandType.Place:
                placeMove = true;
                break;
        }

    }
    private void Update() => _stateMachine.Tick();


}
