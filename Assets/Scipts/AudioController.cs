using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rockpaperscissor
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] List<AudioClip> sfxMusic;
        [SerializeField] AudioSource sfxAudioSrc;
        [SerializeField] AudioSource bgAudioSrc;

        public static AudioController Instance;
        internal static bool soundOn;
        internal static bool musicOn;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;

         
            PlayBgMusic(soundOn);
        }

        public void PlayUISound()
        {
            if (!soundOn) return;
            sfxAudioSrc.PlayOneShot(sfxMusic[0]);
        }

        public void PlayWinSound()
        {
            if (!soundOn) return;
            sfxAudioSrc.PlayOneShot(sfxMusic[1]);
        }

        public void PlayLoseSound()
        {
            if (!soundOn) return;
            sfxAudioSrc.PlayOneShot(sfxMusic[2]);
        }

        public void PlayClickSound()
        {
            if (!soundOn) return;
            sfxAudioSrc.PlayOneShot(sfxMusic[3]);
        }


        public void PlayBlastSound()
        {
            if (!soundOn) return;
            sfxAudioSrc.PlayOneShot(sfxMusic[4]);
        }

        public void PlayBgMusic(bool isOn)
        {
            if (isOn)
                bgAudioSrc.Play();
            else
                bgAudioSrc.Pause();

        }


    }
}