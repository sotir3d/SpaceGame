using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public bool playOnce = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
            s.source.maxDistance = s.maxDistance;
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (!playOnce)
            {
                if (!IsPlaying("GameMusic"))
                {
                    Play("GameMusic");
                    playOnce = true;
                }
            }
        }

        //if (SceneManager.GetActiveScene().buildIndex == 2)
        //{
        //    Stop("Theme1");
        //    Stop("ThemeGameOverScreen");
        //    if (!playOnce)
        //    {
        //        Play("Theme2");
        //        playOnce = true;
        //    }
        //}

        //if (SceneManager.GetActiveScene().buildIndex == 4)
        //{
        //    Stop("Theme1");
        //    Stop("Theme2");
        //    if (!playOnce)
        //    {
        //        Play("ThemeGameOverScreen");
        //        playOnce = true;
        //    }
        //}

        //if (SceneManager.GetActiveScene().buildIndex == 3)
        //{
        //    Stop("Theme1");
        //    Stop("Theme2");
        //    Stop("ThemeGameOverScreen");
        //    if (!playOnce)
        //    {
        //        Play("ThemeThankYou");
        //        playOnce = true;
        //    }
        //}
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Stop();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
            return;
        }
        s.source.Play();
    }

    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "not found!");
        }
        return s.source.isPlaying;
    }
}
