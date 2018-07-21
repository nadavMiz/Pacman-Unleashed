using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public CharecterMovement m_activeCharecter;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_activeCharecter.ChangeDirection(Vector3.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_activeCharecter.ChangeDirection(Vector3.down);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_activeCharecter.ChangeDirection(Vector3.right);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_activeCharecter.ChangeDirection(Vector3.left);
        }
	}
}
