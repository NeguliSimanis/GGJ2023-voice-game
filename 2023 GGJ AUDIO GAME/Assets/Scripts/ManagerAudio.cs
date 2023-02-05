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
        Debug.Log("acquired");
        audioSource.PlayOneShot(philosopherJoined, 1f);
    }

    public void PlaySuccessSFX()
    {
        audioSource.PlayOneShot(inputSuccessSFX, 1f);
    }

    public void PlayFailSFX()
    {
        audioSource.PlayOneShot(failSFX, volumeScale: 0.2f);
    }
}
