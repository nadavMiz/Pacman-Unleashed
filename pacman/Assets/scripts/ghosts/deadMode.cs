using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadMode : MonoBehaviour {

    private delegate void UpdateState();

    public NodeMovement m_movementController;
    public homeOutNode m_homePosition;

    private UpdateState updateState;

    // Update is called once per frame
    void Update ()
    {
        updateState();
    }

    private void ReachHomePosition()
    {
        //reached home node. enter ghost house
        if (IsAtPosition(m_homePosition.transform.position))
        {
            EnterGhostHouse();
        }

        // move to the next position
        if (m_movementController.m_next.IsAtNode(transform.position))
        {
            MoveToNextPosition();
        }
    }

    private void EnterGhostHouse()
    {
        m_movementController.m_next = m_homePosition;
        m_movementController.ChangeDirection(m_homePosition.GetDirectionToCentralNode());
        updateState = EnterGhostHouseUpdate;
    }

    private void EnterGhostHouseUpdate()
    {
        //reached inside ghost house node. return to chase mode
        if (IsAtPosition(m_homePosition.m_centralNode.transform.position))
        {
            SetChaseMode();
        }
    }

    private void OnEnable()
    {
        gameObject.GetComponent<Animator>().SetTrigger("eyes");
        updateState = ReachHomePosition;
    }

    private void MoveToNextPosition()
    {
        Vector2 nextPosition = m_homePosition.transform.position;

        Vector2 direction = GetNextDirection(nextPosition);

        m_movementController.ChangeDirection(direction);
    }

    private Node GetClosestNeighbor(Node _node, Vector2 _target)
    {
        Node closestNode = m_movementController.m_previous;
        float closestDistance = 1000;

        foreach (Node node in _node.m_neighbors)
        {
            float currentDistance = Mathf.Abs(node.transform.position.x - _target.x) + Mathf.Abs(node.transform.position.y - _target.y);

            if (currentDistance < closestDistance && node != m_movementController.m_previous)
            {
                closestNode = node;
                closestDistance = currentDistance;
            }
        }

        return closestNode;
    }

    private Vector2 GetNextDirection(Vector2 _nextPosition)
    {
        Node nextNode = GetClosestNeighbor(m_movementController.m_next, _nextPosition);

        Vector2 direction = nextNode.transform.position - m_movementController.m_next.transform.position;

        return direction.normalized;
    }

    private bool IsAtPosition(Vector2 _position)
    {
        return Vector2.Distance(transform.position, _position) < 0.2;
    }

    private void SetChaseMode()
    {
        enabled = false;
        gameObject.GetComponent<ChaseMode>().enabled = true;
    }
}
