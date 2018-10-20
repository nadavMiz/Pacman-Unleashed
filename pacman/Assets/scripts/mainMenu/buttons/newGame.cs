using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newGame : _Button
{

	override public int Press()
    {
        GameData.instance.SavePlayerPref();
        SceneManager.LoadScene("level1", LoadSceneMode.Single);

        return 0;
    }
}
