using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class movementStrategy : MonoBehaviour
{
    public abstract Vector2 GetNextLocation(GameObject _target);
}
