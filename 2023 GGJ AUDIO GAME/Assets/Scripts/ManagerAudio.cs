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

    // BG MUSIC
    [Header("BG MUSIC")]
    [SerializeField] private List<AudioClip> bgMusic = new List<AudioClip>();
    [SerializeField] private List<AudioSource> bgAudioSources = new List<AudioSource>();
    private int instrumentCount = 0;


    public void SetBackgroundMusic(bool resetInstruments = false)
    {
        if (resetInstruments)
        {
            for (int i = 1; i < bgAudioSources.Count; i++)
            {
                IEnumerator reduceVolume = ChangeVolume(bgAudioSources[i], 1f, 0f);
                StartCoroutine(reduceVolume);
            }
            instrumentCount = 0;
            return;
        }
        instrumentCount++;
        IEnumerator IncreaseVolume = ChangeVolume(bgAudioSources[instrumentCount], 0f, 1f);
        StartCoroutine(IncreaseVolume);
    }

    IEnumerator ChangeVolume(AudioSource source, float startVolume, float endVolume)
    {
        float currentTime = 0;
        float changeTime = 1f;

       
        while (currentTime < changeTime)
        {
            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, endVolume, currentTime / changeTime);

            yield return null;
        }
        yield return null;
    }

    public void PlayPhilosopherSFX()
    {
        //audioSource.PlayOneShot(philosopherJoined, 1f);
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
