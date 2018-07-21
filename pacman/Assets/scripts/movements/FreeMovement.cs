using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovement : CharecterMovement
{
    private Vector2 m_direction = Vector2.right;
    public float m_speed;

    void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position += (Vector3)m_direction * m_speed * Time.deltaTime;
    }

    public override Vector2 GetDirection()
    {
        return m_direction;
    }

    public override bool ChangeDirection(Vector2 _direction)
    {
        m_direction = _direction;

        return true;
    }

    public override float GetSpeed()
    {
        return m_speed;
    }

    public override bool SetSpeed(float _speed)
    {
        m_speed = _speed;

        return true;
    }
}