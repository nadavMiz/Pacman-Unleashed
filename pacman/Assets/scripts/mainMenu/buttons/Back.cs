using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : _Button
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    override public int Press()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        return 0;
    }
}
