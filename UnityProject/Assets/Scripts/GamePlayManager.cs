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
    [SerializeField] private PiecePool _pool;
    private bool placeMove;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _board.GivePiece(_piece);

        var _initBoard = new GState_InitialiseBoard(_board, _blackSquare, _whiteSqwuare);
        var _placePhase = new GState_PlaceYourPiece(_board, _piece, _commander, _pool);
        var _movePhase = new GState_MoveYourPiece(_board, _commander, _pool);

        // Transitions between states.
        At(_initBoard, _placePhase, BoardInitialised());
        At(_placePhase, _movePhase, IntoMoveMode());
        At(_movePhase, _placePhase, IntoPlaceMode());

        // Default State
        _stateMachine.SetState(_initBoard);

        Func<bool> BoardInitialised() => () => _initBoard.BoardReady = true;
        Func<bool> IntoMoveMode() => () => placeMove == true;
        Func<bool> IntoPlaceMode() => () => placeMove == false;

        void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(from: to, to: from, condition);
    }

    public void PlaceMoveToggle(int toggle)
    {
        if(toggle == 0)
        {
            placeMove = false;
        }
        if(toggle == 1)
        {
            placeMove = true;
        }
    }
    private void Update() => _stateMachine.Tick();


}
