using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawn : MonoBehaviour {

    public Node[] m_sideNodes;
    public Node m_middleNode;
    public float m_waitTime;

    private float m_lastTime;
    private int currentNodeToConnect;

    // used by pause and resume. represents the time that already passed until the game was paused
    private float m_timeSinceLastTime = 0.0f; 

	// Use this for initialization
	void Start ()
    {
        EventManager.Subscribe("restart", Restart);
        EventManager.Subscribe("startGame", Restart);
        EventManager.Subscribe("pause", Pause);
        EventManager.Subscribe("resume", Resume);
        enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if(Time.time >= (m_lastTime + m_waitTime))
        {
            m_lastTime = Time.time;
            m_sideNodes[currentNodeToConnect].AttachNode(m_middleNode);
            ++currentNodeToConnect;

            if(currentNodeToConnect == m_sideNodes.Length)
            {
                this.enabled = false;
            }
        }
		
	}

    private void Restart()
    {
        foreach(Node node in m_sideNodes)
        {
            node.RemoveNode(m_middleNode);
        }

        m_lastTime = Time.time;
        currentNodeToConnect = 0;

        this.enabled = true;
    }

    private void Pause()
    {
        m_timeSinceLastTime = Time.time - m_lastTime;
        enabled = false;
    }

    private void Resume()
    {
        m_lastTime = Time.time - m_timeSinceLastTime;
        enabled = true;
    }
}
