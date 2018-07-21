using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinkyChace : movementStrategy
{

    static private float m_targetOffset = 4 * PacmanManager.gridBlockSize;

    public override Vector2 GetNextLocation(GameObject _target)
    {
        Vector2 offset = _target.GetComponent<NodeMovement>().GetDirection() * m_targetOffset;
        return (Vector2)_target.transform.position + offset;
    }
}
