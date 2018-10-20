using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    public Text score;

	void Start ()
    {
        score.text = GameData.instance.m_score.ToString();
    }

    public void UpdateScore(int _newScore)
    {
        score.text = _newScore.ToString();
    }
}
