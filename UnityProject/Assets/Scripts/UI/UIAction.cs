using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAction : MonoBehaviour
{
    [SerializeField]private Text _text;
    [SerializeField]private Image _highLight;
    private int _location;
    private Commander _commander;
    

    public void Initialize (ICommand command, int location, Commander commander)
    {
        _text = GetComponentInChildren<Text>();
        _text.text = (location.ToString() + "  |  " + command.type.ToString());
        _location = location;
        _commander = commander;

    }

    public void Select()
    {
        _highLight.gameObject.SetActive(true);
    }
    public void DeSelect()
    {
        _highLight.gameObject.SetActive(false);
    }

    public void JumpTo()
    {
        _commander.JumpTo(_location);
    }

}
