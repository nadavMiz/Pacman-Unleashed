using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CharecterMovement : MonoBehaviour {

    public abstract Vector2 GetDirection();

    public abstract bool ChangeDirection(Vector2 _direction);

    public abstract float GetSpeed();

    public abstract bool SetSpeed(float _speed);
}
