using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inkyChace : movementStrategy
{
    public Transform m_otherChaser;
    private static float m_targetOffset = 2 * PacmanManager.gridBlockSize;

    public override Vector2 GetNextLocation(GameObject _target)
    {
        Vector2 targetsDirection = _target.GetComponent<NodeMovement>().GetDirection();
        Vector2 midpoint = (Vector2)_target.transform.position + targetsDirection * m_targetOffset;
        Vector2 directionFromOther = midpoint - (Vector2)m_otherChaser.position;

        return (Vector2)m_otherChaser.position + directionFromOther * 2;
    }
}
