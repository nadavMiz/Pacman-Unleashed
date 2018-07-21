using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacman : MonoBehaviour
{
    private Collider2D m_collider;
    public PacmanManager m_manager;
    public AudioSource m_audio;
    public AudioClip m_deathSound;

    public int m_health;

    private void Start()
    {
        m_collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.SendMessage("PacmanCollide", m_collider);
    }

    public void Die()
    {
        m_audio.PlayOneShot(m_deathSound);
        GetComponent<Animator>().SetTrigger("deathTrigger");
    }

    public void ApplyDamage(int _value)
    {
        m_health -= _value;

        m_manager.PacmanHit(this);
    }

}
