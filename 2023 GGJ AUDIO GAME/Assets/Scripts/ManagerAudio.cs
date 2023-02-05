using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAudio : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip failSFX;
    [SerializeField]
    AudioClip inputSuccessSFX;
    [SerializeField]
    AudioClip philosopherJoined;

    public void PlayPhilosopherSFX()
    {
        audioSource.PlayOneShot(philosopherJoined, 1f);
    }

    public void PlaySuccessSFX()
    {
        audioSource.PlayOneShot(inputSuccessSFX, 1f);
    }

    public void PlayFailSFX(float addedVolume = 0f)
    {
        audioSource.PlayOneShot(failSFX, volumeScale: 0.2f + addedVolume);
    }
}
