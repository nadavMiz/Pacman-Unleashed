using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * singleton class to transfer data between different scenes and game sessions
 * the file get initialize once at the beginning of the game and than stay present to the rest of the playthrough
 */
public class GameData : MonoBehaviour
{
    private static GameData g_data;

    /* persistant data between scenes */
    public int m_score;
    public int m_lives;

    /* persistant data between game sessions. (playerPref)*/
    public int m_highScore;
    public int m_startingLives;
    public float m_volume;


    public static GameData instance
    {
        get
        {
            return g_data;
        }
    }

    /**
     * @brief: initialize data that transfer between scenes at the beginning of a new session (new game)
     */
    public void InitialiazeSessionData()
    {
        m_score = 0;
        m_lives = m_startingLives;
    }

    /**
     * @brief: save PlayerPrefs to the disc
     */
    public void SavePlayerPref()
    {
        PlayerPrefs.Save();
    }

    private void Awake()
    {
        /* initiale all values */
        LoadPlayerPrefs();
        InitialiazeSessionData();

        /* set gameobject as singleton */
        if (null != g_data)
        {
            GameObject.Destroy(g_data);
        }
        g_data = this;

        DontDestroyOnLoad(this);
    }

    private void LoadPlayerPrefs()
    {
        m_highScore = PlayerPrefs.GetInt("high score", 0);
        m_startingLives = PlayerPrefs.GetInt("starting lives", 3);
        m_volume = PlayerPrefs.GetFloat("starting lives", 1.0f);
    }

}
