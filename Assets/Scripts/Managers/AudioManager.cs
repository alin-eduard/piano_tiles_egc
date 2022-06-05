using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PianoTilesEGC.Utils;

namespace PianoTilesEGC.Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        public AudioSource MusicSource;

        public void SetAudioClip(AudioClip clip)
        {
            MusicSource.clip = clip;
        }

        public void PlayMusic()
        {
            MusicSource.Play();
        }

        public void StopMusic(float fadeDuration = 0)
        {
            StartCoroutine(StopFadeOut(fadeDuration));
        }

        public void PauseMusic()
        {
            MusicSource.Pause();
        }

        private IEnumerator StopFadeOut(float fadeTime)
        {
            float startVolume = MusicSource.volume;

            while (MusicSource.volume > 0)
            {
                MusicSource.volume -= startVolume * Time.deltaTime / fadeTime;

                yield return null;
            }

            MusicSource.Stop();
            MusicSource.volume = startVolume;
        }
    }
}