using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleeStrategie : movementStrategy
{

    private const int m_maxHeight = 40;
    private const int m_maxWidth = 40;

    public override Vector2 GetNextLocation(GameObject _target)
    {
        return transform.position - (_target.transform.position - transform.position);
    }

    }
