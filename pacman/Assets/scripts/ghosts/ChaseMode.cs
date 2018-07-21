using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMode : MonoBehaviour
{

    public GameObject m_target;
    public NodeMovement m_movementController;
    public movementStrategy m_chaseStrategy;
    public movementStrategy m_scatterStrategy;

    private movementStrategy m_currentStrategy;

    // Use this for initialization
    void Start ()
    {
        m_currentStrategy = m_chaseStrategy;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_movementController.m_next.IsAtNode(transform.position))
        {
            MoveToNextPosition();
        }
    }

    private void OnEnable()
    {
        gameObject.GetComponent<Animator>().SetTrigger("chase");
        gameObject.GetComponent<DamagingObject>().Enable();
    }

    private void OnDisable()
    {
        gameObject.GetComponent<DamagingObject>().Disable();
    }

    public void SetChaceMode()
    {
        m_currentStrategy = m_chaseStrategy;
    }

    public void SetScatterMode()
    {
        m_currentStrategy = m_scatterStrategy;
    }

    public void SetStrategy(movementStrategy _strategy)
    {
        m_currentStrategy = _strategy;
    }

    private void MoveToNextPosition()
    {
        Vector2 nextPosition = m_currentStrategy.GetNextLocation(m_target);

        Vector2 direction = GetNextDirection(nextPosition);

        m_movementController.ChangeDirection(direction);
    }

    private Node GetClosestNeighbor(Node _node, Vector2 _target)
    {
        Node closestNode = m_movementController.m_previous;
        float closestDistance = 1000;

        IEnumerable<Node> neighbors = _node.GetNeighborsForMovement();
        foreach (Node node in neighbors)
        {
            float currentDistance = Mathf.Abs(node.transform.position.x - _target.x) + Mathf.Abs(node.transform.position.y - _target.y);

            if(currentDistance < closestDistance && node != m_movementController.m_previous)
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


}
