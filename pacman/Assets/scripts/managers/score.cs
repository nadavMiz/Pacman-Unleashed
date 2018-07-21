using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

    public Text m_scoreText;

    private int m_score = 0;
    private int m_comboScore = m_comboStartScore;

    private static int m_comboStartScore = 200;
    private static int m_comboMultiplier = 2;

    public int GetScore()
    {
        return m_score;
    }

    public int AddScore(int _toAdd)
    {
        m_score += _toAdd;

        m_scoreText.text = m_score.ToString();

        return m_score;
    }

    public int AddCombo()
    {
        return AddScore(m_comboScore * m_comboMultiplier);
    }

    public void ResetCombo()
    {
        m_comboScore = m_comboStartScore;
    }

    public int GetCurrentComboScore()
    {
        return m_comboScore;
    }
}
