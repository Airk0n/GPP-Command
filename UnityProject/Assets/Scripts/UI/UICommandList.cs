using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICommandList : MonoBehaviour
{
    [SerializeField]private List<UIAction> _actionList = new List<UIAction>();
    [SerializeField]private UIAction prefab;
    private int _currentStep;
    private int _undoStep;
    private bool _upToDate;
    private int _currentHighlight;

    
    public void CommanderStatus(int step,int undo, bool upToDate)
    {

        _currentStep = step;
        _undoStep = undo;
        _upToDate = upToDate;

        if(_currentStep != _undoStep)
        {
            if(_undoStep-1 >= 0)
                Highlight(_undoStep-1);
        }
        if(_upToDate)
        {
            DeSelectAll();
            _currentHighlight = _currentStep - 1;
        }
    }

    public void RemoveFromUndo()
    {

    }
    private void DeSelectAll()
    {
        foreach (UIAction action in _actionList)
        {
            action.DeSelect();
        }
    }

    public void Highlight (int key)
    {
        if(key != _currentHighlight)
        {
            _actionList[_currentHighlight].DeSelect();
            _actionList[key].Select();
            _currentHighlight = key;
        }
    }


    public void AddToList(ICommand command, Commander commander)
    {
        UIAction newAction = Instantiate(prefab, this.transform);
        newAction.Initialize(command, _actionList.Count + 1, commander);
        _actionList.Add(newAction);

    }

    public void NewPath(int newMarker)
    {
        int difference = _actionList.Count-_undoStep;
        for (int i = newMarker; i < _actionList.Count; i++)
        {
            Destroy(_actionList[i].gameObject);
            Destroy(_actionList[i]);

        }
        _actionList.RemoveRange(newMarker, difference);

    }


}
