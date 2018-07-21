using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PacmanManager : MonoBehaviour {

    public Transform m_pickups;
    public soundManager m_audioManager;
    public livesTracker m_livesTracker;
    public StartGame m_startGame;

    public static readonly float gridBlockSize = 0.32f;

    private void Start()
    {
        EventManager.TriggerEvent("pause");
        m_startGame.StartTheGame();
    }

    // Update is called once per frame
    void Update ()
    {
        if (m_pickups.childCount == 0)
        {
            EndGame();
        }
	}

    public void PacmanHit(pacman _pacman)
    {
        m_livesTracker.UpdateLives();
        m_audioManager.StopBackgroundAudio();
        StartCoroutine(PacmanDeathSequance(2.0f));
    }



    IEnumerator PacmanDeathSequance(float _waitTime)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");

        //pause all charecters in game
        EventManager.TriggerEvent("pause");
        player.GetComponent<Animator>().enabled = false;

        // wait while paused for _waitTime seconds
        yield return new WaitForSeconds(_waitTime);

        // make all enemies disapeare
        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<SpriteRenderer>().enabled = false;
        }

        //start pacman death animation
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<pacman>().Die();
        yield return new WaitForSeconds(1.4f);

        //re-enable ghosts
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<SpriteRenderer>().enabled = true;
 
        }

        if (player.GetComponent<pacman>().m_health > 0)
        {
            ResetBoard();
        }
        else
        {
            EndGame();
        }
    }

    private void ResetBoard()
    {
        EventManager.TriggerEvent("restart");
        m_startGame.StartTheGame();
    }

    private void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
