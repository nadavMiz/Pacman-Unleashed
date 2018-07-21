using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    public AudioSource m_audio;
    public AudioClip m_backgroundAudio;

    public void Play(AudioClip _audio)
    {
        m_audio.PlayOneShot(_audio);
    }

    public void PlayBackroundAudio()
    {
        m_audio.clip = m_backgroundAudio;
        m_audio.Play();
    }

    public void StopBackgroundAudio()
    {
        m_audio.Stop();
    }
}
