using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour {

    public float offset; // offset by transform units between buttons
    public ControllManager m_manager; // controll manager of this scene

    private List<_Button> Buttons; 

    private int currentButton = 0;
    private float startPosY; 

    private void Start()
    {
        Buttons = new List<_Button>();
        startPosY = transform.position.y;

        AddAllButtons();
        
    }

    private void OnEnable()
    {
        currentButton = 0;
        m_manager.SetCursor(this);
    }

    /**
     * move the curson up and down to switch between buttons in the menu
     * [in] _direction - direction to move the cursor(Up / Down).
     */
    public void Move(Vector2 _direction)
    {
        if(_direction != Vector2.up && _direction != Vector2.down)
        {
            Debug.Log("curse::move - invalid direction");
        }

        currentButton = MathMod((currentButton - (int)_direction.y), Buttons.Count);

        UpdatePosition();

    }

    /**
     * invoke the Press function of the button that is currently selected (Buttons[currentButton])
     */
    public void Press()
    {
        Buttons[currentButton].Press();
    }

    /**
     * move the cursor to its starting position. also changes the selected button to button 0;
     */
    public void ResetPosition()
    {
        currentButton = 0;
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        float newY = startPosY - (offset * currentButton);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    /**
     * get all buttons in the menu and add them to the list. 
     * the adding is done by index. meanning that the order of the buttons is determend by their order in the hierarchy. 
     */
    private void AddAllButtons()
    {
        Transform parent = transform.parent;

        for (int i = 0; i < parent.childCount; ++i)
        {
            Transform currentChild = parent.GetChild(i);

            _Button button = currentChild.GetComponent<_Button>();
            if (null != button)
            {
                Buttons.Add(button);
            }
        }
    }

    static int MathMod(int a, int b)
    {
        return (Mathf.Abs(a * b) + a) % b;
    }
}