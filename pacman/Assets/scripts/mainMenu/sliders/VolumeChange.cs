using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : _sliderFunction
{
    static private float maxVolume = 5;
    static private float minVolume = 0;

    override public bool Move(Vector2 _direction)
    {
        int newVolume = (int)(GameData.instance.m_volume + _direction.x);
        if (minVolume > newVolume || newVolume > maxVolume)
        {
            return false;
        }

        GameData.instance.m_volume = newVolume;
        return true;
    }
}
