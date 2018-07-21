using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkyChaseStrategy : movementStrategy
{
    public override Vector2 GetNextLocation(GameObject _target)
    {
        return _target.transform.position;
    }
}
