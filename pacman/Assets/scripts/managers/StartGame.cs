using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public soundManager m_audioSource;
    public AudioClip m_startAudio;
    public Text m_readyText;

    public void StartTheGame()
    {
        StartCoroutine(startGameRoutine());
    }

    private IEnumerator startGameRoutine()
    {
        m_readyText.enabled = true;
        m_audioSource.Play(m_startAudio);
        yield return new WaitForSeconds(m_startAudio.length);
        m_audioSource.PlayBackroundAudio();
        EventManager.TriggerEvent("startGame");
        m_readyText.enabled = false;
    }
}
