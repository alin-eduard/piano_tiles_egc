using PianoTilesEGC.Managers;

namespace PianoTilesEGC.Controllers
{
    public class AudioController : IController<AudioController>
    {
        private const float GAME_OVER_FADE_OUT_DURATION = 1.5f;
        private const float FINISH_FADE_OUT_DURATION = 1.7f;
        
        public override void OnStartLevel()
        {
            AudioManager.Instance.StopMusic();
        }

        public override void OnFinishLevel()
        {
            AudioManager.Instance.StopMusic(FINISH_FADE_OUT_DURATION);
        }

        public override void OnGameOver()
        {
            AudioManager.Instance.StopMusic(GAME_OVER_FADE_OUT_DURATION);
        }

        public override void OnPauseLevel()
        {
        }

        public override void OnReloadLevel()
        {
        }

        public override void OnDestroyFirstTile()
        {
            AudioManager.Instance.PlayMusic();
        }

        public override void OnDestroyTile()
        {
        }

        public override void OnPrepareLevel(int levelIndex, bool autoMode = false)
        {
            var levelAudioClip = GameManager.Instance.GetAudioClipLevel(levelIndex);
            AudioManager.Instance.SetAudioClip(levelAudioClip);
        }
    }
}