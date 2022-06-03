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

		//public void Play(AudioClip clip)
		//{
		//	EffectsSource.clip = clip;
		//	EffectsSource.Play();
		//}

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
			MusicSource.Stop();
        }
    }
}
