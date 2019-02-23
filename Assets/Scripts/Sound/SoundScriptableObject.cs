using UnityEngine;

namespace Sound
{
    [CreateAssetMenu(fileName = "SoundObject", menuName = "Custom Objects/Sound/SoundScriptableObject", order = 0)]
    public class SoundScriptableObject : ScriptableObject
    {
        public AudioClip backgroundMusic;
        public AudioClip shootingSound;
        public AudioClip playerDeathSound;
        public AudioClip gameOverSound;

    }




}