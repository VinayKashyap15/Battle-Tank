using UnityEngine;
using System.Collections;
using System;

namespace Sound
{
    public class SoundController : MonoBehaviour
    {
        [SerializeField]
        private SoundEnumType sourceSoundType;
        
        public SoundEnumType GetSourceType()
        {
            return sourceSoundType;
        }

        public AudioSource GetAudioSource()
        {
            return this.GetComponent<AudioSource>();
        }
    }
}