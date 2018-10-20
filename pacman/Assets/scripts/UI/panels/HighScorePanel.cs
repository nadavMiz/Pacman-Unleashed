using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScorePanel : MonoBehaviour {

    public Text score;

	void Start ()
    {
        score.text = GameData.instance.m_highScore.ToString();
	}
}
