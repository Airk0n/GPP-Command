using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    /* Purpose: To contain and run the state machine. It feeds the states with what they need to 
     * manage what the player can interact with.
     */
    private StateMachine _stateMachine;
    [SerializeField] private Board _board;
    [SerializeField] private BoardSquare _blackSquare;
    [SerializeField] private BoardSquare _whiteSqwuare;
    [SerializeField] private Piece _piece;
    [SerializeField] private Commander _commander;

    private void Awake()
    {
        _stateMachine = new StateMachine();

        var _initBoard = new GState_InitialiseBoard(_board, _blackSquare, _whiteSqwuare);
        var _placePhase = new GState_PlaceYourPiece(_board, _piece, _commander);

        // Transitions between states.
        At(_initBoard, _placePhase, BoardInitialised());

        // Default State
        _stateMachine.SetState(_initBoard);

        Func<bool> BoardInitialised() => () => _initBoard.BoardReady = true;

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(from: to, to: from, condition);
    }

    private void Update() => _stateMachine.Tick();


}
