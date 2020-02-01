using UnityEngine;

namespace GGJ.Sound
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        public bool loop;
        [Range(0f, 3f)] public float volume;
        [Range(.1f, 3f)] public float pitch;
        [HideInInspector] public AudioSource source;
    }
}