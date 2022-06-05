using System;
using PianoTilesEGC.Managers;
using UnityEngine;
using UnityEngine.UIElements;

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

        public override void OnStartLevel()
        {
        }

        public override void OnFinishLevel()
        {
            LevelGenerator.Instance.DestroyAllTiles();
        }

        public override void OnGameOver()
        {
            LevelGenerator.Instance.DestroyAllTiles();
        }

        public override void OnDestroyFirstTile()
        {
            isFirstHit = false;
        }

        public override void OnPrepareLevel(int levelIndex, bool autoMode)
        {
            SelectedLevelIndex = levelIndex;
            AutoMode = autoMode;

            var levelData = GameManager.Instance.GetLevelData(levelIndex);
            var levelSettings = GameManager.Instance.GetLevelSettings(levelIndex);

            LevelGenerator.Instance.DestroyAllTiles();
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

# if UNITY_EDITOR
        private void Update()
        {
            // Only for testing
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.Instance.FireOnFinishLevel();
            }
        }
#endif

        public override void OnPauseLevel()
        {
            AudioManager.Instance.PauseMusic();
        }

        public override void OnReloadLevel()
        {
            isFirstHit = true;
        }
    }
}