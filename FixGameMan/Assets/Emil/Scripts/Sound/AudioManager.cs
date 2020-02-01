using UnityEngine;
using System;

namespace GGJ.Sound
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        public Sound[] sounds;
        public bool unmuteOnFocus = true;
        public bool isMuted = false;

        void Awake()
        {
            if (instance == null) instance = this;
            else if (instance != this) Destroy(gameObject);
            DontDestroyOnLoad(gameObject);

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        public void MuteSound()
        {
            foreach (Sound s in sounds)
            {
                s.source.volume = 0f;
            }
            isMuted = true;
        }

        public void UnmuteSound()
        {
            foreach (Sound s in sounds)
            {
                s.source.volume = s.volume;
            }
            isMuted = false;
        }

        public void Play(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            s.source.Play();
        }

        public void Stop(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            s.source.Stop();
        }
    }
}