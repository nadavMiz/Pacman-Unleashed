using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesTracker : MonoBehaviour
{
    private pacman player;
    public Text livesText; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<pacman>();
        UpdateLives();
    }

    public void UpdateLives()
    {
        livesText.text = player.m_health.ToString();
    }
}
