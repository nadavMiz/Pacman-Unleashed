using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scatterStrategy : movementStrategy
{

    public Transform m_fixedPosition;

    public override Vector2 GetNextLocation(GameObject _target)
    {
        return m_fixedPosition.position;
    }
}
