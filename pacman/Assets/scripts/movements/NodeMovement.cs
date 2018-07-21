using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : CharecterMovement
{

    public float m_speed;
    public Node m_previous;
    public Node m_next;

    private Vector2 m_direction;
    private Vector2 m_nextDirection;

    private Node m_startPrevNode;
    private Node m_StarNextNode;
    private Vector3 m_startPosition;

    private Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();

        SetInitialDirection();
        SetInitialVariables();
        EventManager.Subscribe("restart", Restart);
        EventManager.Subscribe("startGame", StartGame);
        EventManager.Subscribe("resume", StartGame);
        EventManager.Subscribe("pause", Pause);

        enabled = false;
    }

    void Update()
    {
        if (!(m_next.IsAtNode(transform.position)))
        {
            MoveForward();
        }
        else
        {
            UpdateNodeValue();
        }
    }

    public override Vector2 GetDirection()
    {
        return m_direction;
    }

    public override bool ChangeDirection(Vector2 _direction)
    {
        if (IsBackwardDirection(_direction))
        {
            MoveBackwards();
            return true;
        }
        else
        {
            m_nextDirection = _direction;
            return false;
        }
         
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

    private void MoveForward()
    {
         transform.position += (Vector3)m_direction * m_speed * Time.deltaTime;
    }

    private void SetInitialDirection()
    {
        Vector2 direction = m_next.transform.position - m_previous.transform.position;
        SetDirection(direction.normalized);

        m_nextDirection = m_direction;
    }

    private void SetInitialVariables()
    {
        m_startPrevNode = m_previous;
        m_StarNextNode = m_next;
        m_startPosition = transform.position;
    }

    private void UpdateNodeValue()
    {
        if (m_next.IsAvialable(m_nextDirection))
        {
            MoveToDirection(m_nextDirection);
        }
        else if (m_next.IsAvialable(m_direction))
        {
            MoveToDirection(m_direction);
        }
    }

    private void MoveToDirection(Vector2 _direction)
    {
        m_previous = m_next;
        m_next = m_next.GetNextAt(_direction);
        SetDirection(_direction);
    }

    private bool IsBackwardDirection(Vector2 _direction)
    {
        Vector2 backward = m_previous.transform.position - m_next.transform.position;
        return _direction == backward.normalized;
    }

    private void MoveBackwards()
    {
        Swap(ref m_next, ref m_previous);

        SetDirection(-m_direction);
        m_nextDirection = m_direction;
    }

    private void SetDirection(Vector2 _direction)
    {
        if (m_direction != _direction)
        {
            m_direction = _direction;
            ChangeAnimation(_direction);
        }
    }

    private void ChangeAnimation(Vector2 _direction)
    {
        m_animator.SetInteger("horizontalDirection", (int)_direction.x);
        m_animator.SetInteger("verticalDirection", (int)_direction.y);
        m_animator.SetTrigger("changeDirection");
    }

    void Restart()
    {
        m_previous = m_startPrevNode;
        m_next = m_StarNextNode;
        transform.position = m_startPosition;

        SetInitialDirection();
    }

    void StartGame()
    {
        this.enabled = true;
        m_animator.enabled = true;
    }

    void Pause()
    {
        this.enabled = false;
    }

    static private void Swap(ref Node _a, ref Node _b)
    {
        Node tmp = _a;
        _a = _b;
        _b = tmp;
    }
}
