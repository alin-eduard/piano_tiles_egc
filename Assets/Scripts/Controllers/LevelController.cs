using PianoTilesEGC.Managers;

namespace PianoTilesEGC.Controllers
{
    public class LevelController : IController
    {
        private int destroyedTiles;
        private int tilesThatShouldDestroyed;
        private bool isFirstHit;

        public override void OnStartLevel() { }

        public override void OnFinishLevel() 
        {
            AudioManager.Instance.StopMusic();
        }

        public override void OnGameOver()
        {
            AudioManager.Instance.StopMusic();
        }
        public override void OnDestroyFirstTile() 
        {
            isFirstHit = false;
            AudioManager.Instance.PlayMusic();
        }

        public override void OnPrepareLevel(int levelIndex)
        {
            var levelData = GameManager.Instance.GetLevelData(levelIndex);
            var levelSettings = GameManager.Instance.GetLevelSettings(levelIndex);
            var levelAudioClip = GameManager.Instance.GetAudioClipLevel(levelIndex);

            AudioManager.Instance.SetAudioClip(levelAudioClip);
            LevelGenerator.Instance.GenerateLevel(levelData, levelSettings, out tilesThatShouldDestroyed);
           
            destroyedTiles = 0;
            isFirstHit = true;
        }

        public override void OnDestroyTile()
        {
            destroyedTiles++;

            if (isFirstHit == true)
            {
                GameManager.Instance.FireOnDestroyFirstTile();
            }

            if (destroyedTiles == tilesThatShouldDestroyed)
            {
                GameManager.Instance.FireOnFinishLevel();
            }
        }
    }
}