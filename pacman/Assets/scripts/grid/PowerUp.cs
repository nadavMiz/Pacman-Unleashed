using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    static private int m_scoreVal = 20;

    private score m_scorer;
    private ghostBehaviourManager m_ghostManager;

    private void Start()
    {
        m_scorer = GameObject.Find("score").GetComponent<score>();
        m_ghostManager = GameObject.Find("manager").GetComponent<ghostBehaviourManager>();
    }

    public void PacmanCollide(Collider2D _pacman)
    {
        m_scorer.AddScore(m_scoreVal);
        m_ghostManager.StartFleeMode();
        Destroy(gameObject);
    }
}
