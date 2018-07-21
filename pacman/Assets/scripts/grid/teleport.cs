using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Node m_target;

    public void PacmanCollide(Collider2D _pacman)
    {
        NodeMovement pacmanMovement = _pacman.GetComponent<NodeMovement>();

        _pacman.transform.position = m_target.transform.position;

        pacmanMovement.m_previous = m_target;
        pacmanMovement.m_next = m_target.GetNextAt(pacmanMovement.GetDirection());
    }
}
