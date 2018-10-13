using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : _Button
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    override public int Press()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        return 0;
    }
}
