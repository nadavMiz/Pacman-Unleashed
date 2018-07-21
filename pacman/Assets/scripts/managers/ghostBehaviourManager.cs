using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostBehaviourManager : MonoBehaviour {

    static private float m_fleeTime = 8.0f;

    public ChaseMode[] m_ghosts;
    public float[] m_transitionTimes;
    public score m_scorer;

    private int currentTimeIdx = 0;
    private float m_switchTime;

    private void Start()
    {
        EventManager.Subscribe("restart", Restart);
        EventManager.Subscribe("pause", Pause);
        EventManager.Subscribe("startGame", Restart);
        EventManager.Subscribe("resume", Resume);
        enabled = false;
    }

    private void OnEnable()
    {
        m_switchTime = Time.time + m_transitionTimes[currentTimeIdx];
    }

    // Update is called once per frame
    void Update ()
    {
		if(Time.time > m_switchTime)
        {
            foreach (ChaseMode ghost in m_ghosts)
            {
                // switch between statements
                if (currentTimeIdx % 2 == 0)
                {
                    ghost.SetChaceMode();
                }
                else
                {
                    ghost.SetScatterMode();
                }
            }

            ++currentTimeIdx;

            if (currentTimeIdx == m_transitionTimes.Length)
            {
                this.enabled = false;
                return;
            }
            else
            {
                m_switchTime = Time.time + m_transitionTimes[currentTimeIdx];
            }
        }
	}

    public void StartFleeMode()
    {
        this.enabled = false;
        m_scorer.ResetCombo();

        foreach (ChaseMode ghost in m_ghosts)
        {
            ghost.enabled = false;
            ghost.gameObject.GetComponent<fleeMode>().enabled = true;
            ghost.gameObject.GetComponent<fleeMode>().SetTimerToReturnToChaceMode(m_fleeTime);
        }

        StartCoroutine(FleeSequance(m_fleeTime));
    }

    public void Restart()
    {
        currentTimeIdx = 0;
        this.enabled = true;
    }

    public void Pause()
    {
        this.enabled = false;
    }

    public void Resume()
    {
        this.enabled = true;
    }

    private IEnumerator FleeSequance(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        m_switchTime = Time.time + m_transitionTimes[currentTimeIdx];
        this.enabled = true;
    }
}
