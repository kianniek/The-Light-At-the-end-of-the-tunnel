using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // definition of a sound for easy management
    [Serializable]
    internal struct Sound
    {
        public AudioClip clip;
        [Range(0, 1)] public float volume;
    }

    // all defined sounds
    [SerializeField] private List<Sound> sounds;

    // audio sources
    [SerializeField] private AudioSource AudioSource;

    // current volume for all sources
    private float currentVolume;

    internal void Initialize()
    {
        // set volume and force an update
        OnVolumeChanged(0.5f, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        SetAndPlayMusic(0);
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

}
