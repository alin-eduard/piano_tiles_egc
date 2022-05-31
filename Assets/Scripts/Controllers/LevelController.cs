using System;
using UnityEngine;
using PianoTilesEGC.Level;
using PianoTilesEGC.Managers;
using PianoTilesEGC.DataLevel;
using PianoTilesEGC.ReaderParserSystem;

namespace PianoTilesEGC.Controllers
{
    public class LevelController : IController
    {
        private int destroyedTiles;
        private int tilesThatShouldDestroyed;

        public override void OnStartLevel() { }

        public override void OnFinishLevel() { }

        public override void OnGameOver() { }

        public override void OnPrepareLevel(int levelIndex)
        {
            var levelData = GetLevelData(levelIndex);
            //var levelAudioClio = GetAudioClipLevel(levelIndex);
            var levelSettings = GetLevelSettings(levelIndex);

            LevelGenerator.Instance.GenerateLevel(levelData, levelSettings, out tilesThatShouldDestroyed);
            destroyedTiles = 0;
        }

        public override void OnDestroyTile()
        {
            destroyedTiles++;
            if (destroyedTiles == tilesThatShouldDestroyed)
            {
                GameManager.Instance.FireOnFinishLevel();
            }
        }

        #region Private Methods
        private LevelData GetLevelData(int indexLevel)
        {
            try
            {
                var levelFileName = GameManager.Instance.LevelsContainer.LevelFileName[indexLevel];
                var jsonLevel = JsonReader.ReadJson(levelFileName);
                var levelData = JsonParser.ParseJson(jsonLevel);
                return levelData;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private AudioClip GetAudioClipLevel(int indexLevel)
        {
            try
            {
                return GameManager.Instance.LevelsContainer.LevelsSong[indexLevel];
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private LevelSettings GetLevelSettings(int indexLevel)
        {
            try
            {
                return GameManager.Instance.LevelsContainer.LevelsSettings[indexLevel];
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        #endregion
    }
}