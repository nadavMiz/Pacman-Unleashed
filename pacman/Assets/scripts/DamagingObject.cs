using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingObject : MonoBehaviour {

    public int m_damage;
    private bool isEnabled = true;

    public void Enable()
    {
        isEnabled = true;
    }

    public void Disable()
    {
        isEnabled = false;
    }

    public void PacmanCollide(Collider2D _pacman)
    {
        if (isEnabled)
        {
            _pacman.SendMessage("ApplyDamage", m_damage);
        }
    }
}
