using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{

    public _sliderFunction function;
    public _sliderEffect effect;

    public bool Move(Vector2 _direction)
    {
        if (_direction != Vector2.right || _direction != Vector2.left)
        {
            return false;
        }

        if (!function.Move(_direction))
        {
            return false;
        }

        if (!effect.Move(_direction))
        {
            Debug.LogError("can't move slider effect even though slider function succeeded");
        }

        return true;
    }
}
