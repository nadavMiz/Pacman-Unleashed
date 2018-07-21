using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clydeChace : movementStrategy
{

    public movementStrategy m_scatterStrategy;

    private static float m_transitionDistance = 8.0f * PacmanManager.gridBlockSize;

    public override Vector2 GetNextLocation(GameObject _target)
    {
        if (Vector2.Distance(_target.transform.position, transform.position) > m_transitionDistance)
        {
            return _target.transform.position;
        }
        else
        {
            return m_scatterStrategy.GetNextLocation(_target);
        }
    }
}
