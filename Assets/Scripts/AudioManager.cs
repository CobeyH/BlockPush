using System;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public AudioMixerGroup mainMixer;

    public static AudioManager instance;

    private Sound currentSong;
    private List<AudioSource> activeAudioSources = new List<AudioSource>();

    // Start is called before the first frame update
    void Awake()
    {
        // Audio manager implements the singleton pattern so that music doesn't stop between scenes.
        if (instance != null)
        {
            GameObject.Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);

        AddAudioSources(sounds);
    }

    void AddAudioSources(Sound[] clips)
    {
        foreach (Sound s in clips)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = mainMixer;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
            return;
        }
        else
        {
            Debug.LogWarning("Sound not found with name: " + name);
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Stop();
            return;
        }
    }

    public void PauseAllSounds()
    {
        activeAudioSources.Clear();
        foreach (Sound s in sounds)
        {
            if (s.source.isPlaying)
            {
                activeAudioSources.Add(s.source);
                s.source.Pause();
            }
        }
    }

    public void ResumeSounds()
    {
        foreach (AudioSource s in activeAudioSources)
        {
            s.UnPause();
        }
    }
}

