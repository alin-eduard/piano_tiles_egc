using System;
using PianoTilesEGC.Managers;
using UnityEngine;

namespace PianoTilesEGC.Controllers
{
    public class LevelController : IController<LevelController>
    {
        [SerializeField] private GameObject normalPlayMode;
        [SerializeField] private GameObject autoPlayMode;
        
        [HideInInspector] public int SelectedLevelIndex;
        [HideInInspector] public bool AutoMode;

        private int destroyedTiles;
        private int tilesThatShouldDestroyed;
        private bool isFirstHit;

        public override void OnStartLevel() { }

        public override void OnFinishLevel() 
        {
            AudioManager.Instance.StopMusic();
            LevelGenerator.Instance.DestroyAllTiles();
        }

        public override void OnGameOver()
        {
            AudioManager.Instance.StopMusic();
            LevelGenerator.Instance.DestroyAllTiles();
        }


        public override void OnDestroyFirstTile() 
        {
            isFirstHit = false;
            AudioManager.Instance.PlayMusic();
        }

        public override void OnPrepareLevel(int levelIndex, bool autoMode)
        {
            SelectedLevelIndex = levelIndex;
            AutoMode = autoMode;
            
            var levelData = GameManager.Instance.GetLevelData(levelIndex);
            var levelSettings = GameManager.Instance.GetLevelSettings(levelIndex);
            var levelAudioClip = GameManager.Instance.GetAudioClipLevel(levelIndex);

            AudioManager.Instance.SetAudioClip(levelAudioClip);
            LevelGenerator.Instance.GenerateLevel(levelData, levelSettings, out tilesThatShouldDestroyed);

            autoPlayMode.SetActive(autoMode);
            normalPlayMode.SetActive(!autoMode);
            
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