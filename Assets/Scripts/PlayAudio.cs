using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaySound
{
    public class PlayAudio : MonoBehaviour
    {
        public AudioClip audioClip;
        AudioSource audioSource;
        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        public void Play()
        {
            audioSource.PlayOneShot(audioClip, 0.3f);
        }
    }
}

