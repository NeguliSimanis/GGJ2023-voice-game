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

    public void PlaySuccessSFX()
    {
        audioSource.PlayOneShot(inputSuccessSFX, 1f);
        Debug.Log("succ");
    }

    public void PlayFailSFX()
    {
        Debug.Log("suck");
        audioSource.PlayOneShot(failSFX, volumeScale: 0.2f);
    }
}
