using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // definition of a sound for easy management
    [Serializable]
    internal struct Sound
    {
        public AudioClip clip;
        //[Range(0, 1)] public float volume;
        [Range(0, 100)] public float stopAfterSeconds;
        public bool fadeOut;
    }

    // all defined sounds
    [SerializeField] private List<Sound> sounds;

    // audio sources
    [SerializeField] private AudioSource AudioSource;

    // current volume for all sources
    private float currentVolume;
    float safeVolume;
    bool hasTriggered;
    bool savedVolume = false;
    bool startCountDown = false;
    internal void Initialize()
    {
        // set volume and force an update
        OnVolumeChanged(0.5f, true);

    }
    private void Start()
    {
        AudioSource.rolloffMode = AudioRolloffMode.Linear;
        if (!savedVolume)
        {
            safeVolume = AudioSource.volume;
            savedVolume = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        AudioSource.volume = 0;
        SetAndPlayMusic(0);
        AudioSource.volume = safeVolume;
        hasTriggered = true;
    }

    private void Update()
    {
        if (hasTriggered)
        {
            if (sounds[0].stopAfterSeconds != 0)
            {
                {
                    StartCoroutine(StopPlayingAfterSeconds(sounds[0].stopAfterSeconds, sounds[0].fadeOut));
                }
            }
        }
    }
    internal void OnVolumeChanged(float newVolume, bool forceUpdate = false)
    {
        // return if there is no change and it isn't a forced update
        if (!forceUpdate && newVolume == currentVolume)
            return;

        // set all sources to new volume
        // and keep track of current volume
        AudioSource.volume = currentVolume = newVolume;
    }

    internal void PlayMusic(bool play)
    {
        // either play or pause the music source
        if (play)
            AudioSource.Play();
        else
            AudioSource.Pause();
    }

    internal bool GetMusicIsPlaying()
    {
        return AudioSource.isPlaying;
    }

    internal float GetMusicPlaytime()
    {
        return AudioSource.time;
    }

    internal void StopMusic()
    {
        AudioSource.Stop();
    }

    internal void SetMusicClip(AudioClip clip)
    {
        AudioSource.clip = clip;
    }
    internal void SetAndPlayMusic(int soundIndex)
    {
        SetMusicClip(sounds[soundIndex].clip);
        PlayMusic(true);
    }

    bool boolcheck;
    internal IEnumerator StopPlayingAfterSeconds(float playTime, bool fadeOut)
    {
        if (!boolcheck)
        {
            StartCoroutine(MuteForSeconds(0.1f));
            StartCoroutine(HalfVolume(playTime / 2));
            boolcheck = true;
        }

        startCountDown = true;
        yield return new WaitForSeconds(playTime);
        if (fadeOut)
        {
            if (startCountDown)
            {

                if (AudioSource.volume > 0)
                {
                    AudioSource.volume -= 0.35f * Time.deltaTime;
                }
                if (AudioSource.volume <= 0)
                {
                    StopMusic();
                    StopAllCoroutines();
                    startCountDown = false;
                    yield return null;
                }
            }
        }
        else
        {
            StopMusic();
            StopAllCoroutines();
            yield return null;
        }
    }
    private IEnumerator HalfVolume(float waitBeforeHalfing)
    {
        yield return new WaitForSeconds(waitBeforeHalfing);
        AudioSource.volume = AudioSource.volume / 2f;
        StopCoroutine(HalfVolume(waitBeforeHalfing));
    }
    private IEnumerator MuteForSeconds(float wait)
    {
        AudioSource.volume = 0;
        yield return new WaitForSeconds(wait);
        AudioSource.volume = safeVolume;

    }
    public void Reset()
    {
        StopMusic();
        StopAllCoroutines();
        AudioSource.volume = safeVolume;
    }
}
