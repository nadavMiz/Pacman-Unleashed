using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPickup : MonoBehaviour
{
    static private int m_scoreVal = 10;

    public AudioClip m_sound;
    private AudioSource m_source;

    private score m_scorer;

    private void Start()
    {
        m_source = GameObject.Find("manager").GetComponentInChildren<AudioSource>();
        m_scorer = GameObject.Find("score").GetComponent<score>();
    }
    public void PacmanCollide(Collider2D _pacman)
    {
        m_scorer.AddScore(m_scoreVal);
        m_source.PlayOneShot(m_sound);

        Destroy(gameObject);
    }
}
