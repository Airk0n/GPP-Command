using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAction : MonoBehaviour
{
    [SerializeField]private Text text;
    [SerializeField]private Image highLight;

    public void Initialize (ICommand command, int location)
    {
        text = GetComponentInChildren<Text>();
        text.text = (location.ToString() + "  |  " + command.type.ToString());

    }

    public void Select()
    {
        highLight.gameObject.SetActive(true);
    }
    public void DeSelect()
    {
        highLight.gameObject.SetActive(false);
    }

}
