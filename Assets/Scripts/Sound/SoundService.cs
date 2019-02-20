using UnityEngine;
using GameplayInterfaces;
using System.Collections.Generic;
using System;
using GameplayInterfaces;
using ServiceLocator;


namespace Sound
{
    public class SoundService :ISoundService
    {
        private SoundScriptableObject currentSoundObj;
        public AudioClip backgroundMusic;
        public AudioClip shootingSound;
        public AudioClip playerDeath;
        public AudioClip gameOver;
        private List<SoundController> currentAudioSources= new List<SoundController>();
        


        public SoundService(SoundScriptableObject _soundObject, List<SoundController>  listOfAudioSources)
        {
            currentAudioSources = listOfAudioSources;
            currentSoundObj=_soundObject;
            backgroundMusic=currentSoundObj.backgroundMusic;
            shootingSound=currentSoundObj.shootingSound;
            playerDeath=currentSoundObj.playerDeathSound;
            gameOver=currentSoundObj.gameOverSound;
            
            RegisterFunctions();
            PlayBackgroundSound();
        }

        private void RegisterFunctions()
        {
            GameApplication.Instance.GetService<IPlayerService>().PlayerDeath += PlayDeathSound;
            GameApplication.Instance.GetService<IStateMachineService>().OnEnterGameOverScene += PlayGameOverSound;
            GameApplication.Instance.GetService<IStateMachineService>().OnPause += OnPause;
            GameApplication.Instance.GetService<IStateMachineService>().OnResume += OnResume;
        }

        private void PlayBackgroundSound()
        {
           
            foreach(SoundController _controller in currentAudioSources)
            {
                if(_controller.GetSourceType()== SoundEnumType.BACKGROUND)
                {
                    _controller.GetAudioSource().clip = backgroundMusic;
                    _controller.GetAudioSource().Play();
                    return;
                }
            }
            
        }

        private void PlayDeathSound(int x, int y)
        {
            foreach (SoundController _controller in currentAudioSources)
            {
                if (_controller.GetSourceType() == SoundEnumType.SOUND_EFFECTS)
                {                    
                    _controller.GetAudioSource().PlayOneShot(playerDeath);
                    return;
                }
            }
        }

        private void PlayGameOverSound()
        {
            foreach (SoundController _controller in currentAudioSources)
            {
                if (_controller.GetSourceType() == SoundEnumType.SOUND_EFFECTS)
                {                    
                    _controller.GetAudioSource().PlayOneShot(gameOver);
                    return;
                }
            }
            
        }

        private void PlayShootSound()
        {
            foreach (SoundController _controller in currentAudioSources)
            {
                if (_controller.GetSourceType() == SoundEnumType.SOUND_EFFECTS)
                {                    
                    _controller.GetAudioSource().PlayOneShot(shootingSound);
                    return;
                }
            }            
        }
        private void OnPause()
        {
            AudioListener.volume = 0;
        }
        private void OnResume()
        {
            AudioListener.volume = 1;
        }
    }
}