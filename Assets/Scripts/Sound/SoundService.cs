using UnityEngine;
using GameplayInterfaces;
using System.Collections.Generic;
using System;


namespace Sound
{
    public class SoundService :ISoundService
    {
        private SoundScriptableObject currentSoundObj;
        public AudioClip backgroundMusic;
        public AudioClip shootingSound;
        public AudioClip playerDeath;
        public AudioClip gameOver;
        private AudioSource currentAudioSource;

        public SoundService(SoundScriptableObject _soundObject, AudioSource _audioSource)
        {
            currentSoundObj=_soundObject;
            currentAudioSource=_audioSource;

            backgroundMusic=currentSoundObj.backgroundMusic;
            shootingSound=currentSoundObj.shootingSound;
            playerDeath=currentSoundObj.playerDeathSound;
            gameOver=currentSoundObj.gameOverSound;
        }
        public void PlayBackgroundSound()
        {
            //throw new NotImplementedException();
            

            
        }

        public void PlayDeathSound()
        {
            throw new NotImplementedException();
        }

        public void PlayGameOverSound()
        {
            throw new NotImplementedException();
        }

        public void PlayShootSound()
        {
            throw new NotImplementedException();
        }
    }
}