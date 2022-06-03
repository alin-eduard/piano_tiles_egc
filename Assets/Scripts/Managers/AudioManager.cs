using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PianoTilesEGC.Utils;

namespace PianoTilesEGC.Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
		//public AudioSource EffectsSource;
		public AudioSource MusicSource;
		
		public float LowPitchRange = 0.95f;
		public float HighPitchRange = 1.05f;

		public void SetAudioClip(AudioClip clip)
        {
			MusicSource.clip = clip;
        }

		public void PlayMusic()
		{
			MusicSource.Play();
		}

        public void StopMusic()
        {
	        StartCoroutine(StopFadeOut(1f));
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
