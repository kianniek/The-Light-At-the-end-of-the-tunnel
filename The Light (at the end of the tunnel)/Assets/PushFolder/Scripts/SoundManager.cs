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
    [Serializable]
    public struct Sound
    {
        public AudioClip clip;
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
        //set the adiosource loop bool to the same value we give to the scruct.
        AudioSource.loop = sounds[0].loop;
        //AudioSource.rolloffMode = AudioRolloffMode.Linear;
        if (!savedVolume)
        {
            //safe the volume for later use
            safeVolume = AudioSource.volume;
            savedVolume = true;
        }
    }

    [SerializeField] private bool isPlayed = false;
    private void OnTriggerEnter(Collider other)
    {
        //if we dont want the player to trigger the sound look for anything but the player
        if (!sounds[0].triggerWithPlayer && !other.CompareTag("Player"))
        {
            if (!isPlayed || (sounds[0].Repeat && repeatCounter < sounds[0].repeatTimes))
            {
                AudioSource.volume = safeVolume;
                SetAndPlayMusic(0);
                isPlayed = true;
            }
        }
        //if we want (just) the player to trigger the sound look for the player 
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
    //not in use
    internal bool GetMusicIsPlaying()
    {
        //see if there is music playing
        return AudioSource.isPlaying;
    }

    //not in use
    internal float GetMusicPlaytime()
    {
        //see how long the music has been playing for
        return AudioSource.time;
    }

    internal void StopMusic()
    {
        //stops the music and set isPlayed to false
        AudioSource.Stop();
        isPlayed = false;
    }

    internal void SetMusicClip(AudioClip clip)
    {
        //set the audioclip to a specific clip
        AudioSource.clip = clip;
    }
    public void SetAndPlayMusic(int soundIndex)
    {
        //increases the repeatCounter and set the music clip to the current sound
        repeatCounter++;
        SetMusicClip(sounds[soundIndex].clip);

        // check if we want the music to stop after a couple seconds
        if (sounds[soundIndex].stopAfterSeconds > 0)
        {
            //if so start the coroutine
            PlayMusic(true);
            StartCoroutine(StopPlayingAfterSeconds(sounds[soundIndex].stopAfterSeconds, sounds[soundIndex].fadeOut));
        }
        else
        {
            //if not just continue playing until the sound stops
            PlayMusic(true);
            isPlayed = false;
        }
    }

    public bool boolcheck;
    internal IEnumerator StopPlayingAfterSeconds(float playTime, bool fadeOut)
    {
        //boolcheck to only do these functions once
        if (!boolcheck)
        {
            StartCoroutine(MuteForSeconds(0.1f));
            boolcheck = true;
        }
        //ready the countdown
        yield return new WaitForSeconds(playTime);
        //after the given playtime for the music check if we want a fadeout 
        //if we want a countdown continue
        if (fadeOut)
        {
            //if the volume is higher than 0, gradually lower it to simulate a fadeout
            if (AudioSource.volume > 0)
            {
                AudioSource.volume -= 0.35f * Time.deltaTime;
            }
            //if the volume is 0, stop playing and stop all coroutines
            if (AudioSource.volume <= 0)
            {
                StopMusic();
                StopAllCoroutines();
                startCountDown = false;
                yield return null;
            }
        }
        else
        {
            //if we dont want a fadeout just stop the music after the playtime
            StopMusic();
            StopAllCoroutines();
            yield return null;
        }
    }
    //not in use
    private IEnumerator HalfVolume(float waitBeforeHalfing)
    {
        yield return new WaitForSeconds(waitBeforeHalfing);
        AudioSource.volume = AudioSource.volume / 2f;
        StopCoroutine(HalfVolume(waitBeforeHalfing));
    }
    private IEnumerator MuteForSeconds(float wait)
    {
        //mute the sound for a fraction of a second to prevent the pop
        //we sometimes hear when a sound is played
        AudioSource.volume = 0;
        yield return new WaitForSeconds(wait);
        AudioSource.volume = safeVolume;

    }
    public void Reset()
    {   
        //stop the music, all coroutines
        //reset the volume and put the repeat counter to 0
        //set the isPlayed bool to false
        StopMusic();
        StopAllCoroutines();
        AudioSource.volume = safeVolume;
        repeatCounter = 0;
        isPlayed = false;
    }
}
