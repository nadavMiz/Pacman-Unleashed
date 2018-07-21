using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleeMode : MonoBehaviour
{
    public NodeMovement m_movementController;
    public score m_scorer;

    private bool isEnabled = false;
    static private float speedMultiplier = 0.5f;

    public void SetTimerToReturnToChaceMode(float _time)
    {
        StartCoroutine(TimerToChaceMode(_time));
    }

    private void Update()
    {
        if (m_movementController.m_next.IsAtNode(transform.position))
        {
            MoveToNextPosition();
        }
    }

    private void OnEnable()
    {
        //slow the ghost down
        m_movementController.SetSpeed(m_movementController.GetSpeed() * speedMultiplier);

        //reverse direction
        m_movementController.ChangeDirection(-m_movementController.GetDirection());

        gameObject.GetComponent<Animator>().SetTrigger("flee");

        isEnabled = true;
    }

    private void OnDisable()
    {
        //return ghost to previous speed
        m_movementController.SetSpeed(m_movementController.GetSpeed() / speedMultiplier);

        //if timer to chase mode exists stop it
        StopAllCoroutines();

        isEnabled = false;
    }

    public void PacmanCollide(Collider2D _pacman)
    {
        if (isEnabled)
        {
            m_scorer.AddCombo();

            Die();
        }
    }

    private Node GetRandomNode()
    {
        Node currentNode = m_movementController.m_next;
        Node targetNode = m_movementController.m_previous;

        //the only avialable node is the previous one
        if (currentNode.m_neighbors.Count == 1)
        {
            return targetNode;
        }

        while (targetNode == m_movementController.m_previous)
        {
            targetNode = currentNode.m_neighbors[Random.Range(0, currentNode.m_neighbors.Count)];
        }

        return targetNode;

    }

    private void MoveToNextPosition()
    {
        Node targetNode = GetRandomNode();

        Vector2 direction = targetNode.transform.position - m_movementController.m_next.transform.position;

        m_movementController.ChangeDirection(direction.normalized);

    }

    private void Die()
    {
        enabled = false;
        gameObject.GetComponent<deadMode>().enabled = true;
    }

    private IEnumerator TimerToChaceMode(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        enabled = false;
        gameObject.GetComponent<ChaseMode>().enabled = true;
    }
}

