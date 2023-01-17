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
    public struct Sound
    {
        public AudioClip clip;
        //[Range(0, 1)] public float volume;
        [Range(0, 100)] public float stopAfterSeconds;
        public bool fadeOut;
        public bool Repeat;
        public bool triggerWithPlayer;
        public bool loop;
        [Range(0, 10)] public int repeatTimes;
    }
    private int repeatCounter;

    // all defined sounds
    [SerializeField] public List<Sound> sounds;

    // audio sources
    [SerializeField] private AudioSource AudioSource;

    // current volume for all sources
    private float currentVolume;
    float safeVolume;
    bool savedVolume = false;
    bool startCountDown = false;
    internal void Initialize()
    {
        // set volume and force an update
        OnVolumeChanged(0.5f, true);

    }
    private void Start()
    {
        AudioSource.loop = sounds[0].loop;
        //AudioSource.rolloffMode = AudioRolloffMode.Linear;
        if (!savedVolume)
        {
            safeVolume = AudioSource.volume;
            savedVolume = true;
        }
    }

    [SerializeField]private bool isPlayed = false;
    private void OnTriggerEnter(Collider other)
    {

        if (!sounds[0].triggerWithPlayer && !other.CompareTag("Player"))
        {
            if (!isPlayed || (sounds[0].Repeat && repeatCounter < sounds[0].repeatTimes))
            {
                AudioSource.volume = safeVolume;
                SetAndPlayMusic(0);
                isPlayed = true;
            }
        }
        if (sounds[0].triggerWithPlayer && other.CompareTag("Player"))
        {
            if (!isPlayed || (sounds[0].Repeat && repeatCounter < sounds[0].repeatTimes))
            {
                AudioSource.volume = safeVolume;
                SetAndPlayMusic(0);
                isPlayed = true;
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
        isPlayed = false;
    }

    internal void SetMusicClip(AudioClip clip)
    {
        AudioSource.clip = clip;
    }
    public void SetAndPlayMusic(int soundIndex)
    { 
        repeatCounter++;
        SetMusicClip(sounds[soundIndex].clip);

        if(sounds[soundIndex].stopAfterSeconds > 0)
        {
            PlayMusic(true);
            StartCoroutine(StopPlayingAfterSeconds(sounds[soundIndex].stopAfterSeconds, sounds[soundIndex].fadeOut));
        }
        else
        {
            PlayMusic(true);
            isPlayed = false;
        }
    }

    public bool boolcheck;
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
        repeatCounter = 0;
        isPlayed = false;
    }
}
