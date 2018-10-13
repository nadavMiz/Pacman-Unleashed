using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenu : _Button
{

    public GameObject m_menuToSwitch;

    private GameObject m_ParentMenu;
    private cursor m_ParentCursor;

    void Start ()
    {
        m_ParentMenu = transform.parent.gameObject;
        m_ParentCursor = m_ParentMenu.GetComponentInChildren<cursor>();
    }

    override public int Press()
    {
        m_ParentCursor.ResetPosition();
        m_ParentMenu.SetActive(false);
        m_menuToSwitch.SetActive(true);
        return 0;
    }
}
