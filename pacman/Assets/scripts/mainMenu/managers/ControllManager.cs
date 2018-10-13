using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllManager : MonoBehaviour
{
    public cursor m_cursor;
 
    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_cursor.Move(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_cursor.Move(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_cursor.Press();
        }
    }

    public void SetCursor(cursor _cursor)
    {
        m_cursor = _cursor;
    }
}
