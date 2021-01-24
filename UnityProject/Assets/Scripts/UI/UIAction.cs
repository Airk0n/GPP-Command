using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAction : MonoBehaviour
{
    /* Purpose:
     * This object represents UI element called an Action that represents a command in the command list.
     * It simple displays what the command is that it represents and can be selected and deselcted to show where we are in the undo history.
     */
    [SerializeField]private Text _text;
    [SerializeField]private Image _highLight;

    private int _location;
    private Commander _commander;
    
    /* similarly to the commands created in commander, upon instatiation this object is given the data it needs to display
     * However as this is used on a prefab a contructor cannot be used and init is called instead.
     */
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
