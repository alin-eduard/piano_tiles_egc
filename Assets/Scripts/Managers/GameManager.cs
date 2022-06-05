using System;
using PianoTilesEGC.Controllers;
using UnityEngine;
using PianoTilesEGC.Level;
using PianoTilesEGC.Utils;
using PianoTilesEGC.DataLevel;
using PianoTilesEGC.ReaderParserSystem;

namespace PianoTilesEGC.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private LevelsContainer levelsContainer;
        public LevelsContainer LevelsContainer => levelsContainer;

        public Action OnStartLevel;
        public Action OnGameOver;
        public Action OnFinishLevel;
        public Action OnDestroyTile;
        public Action<int, bool> OnPrepareLevel;
        public Action OnDestroyFirstTile;
        public Action OnPauseLevel;
        public Action OnReloadLevel;

        public void FireOnStartLevel()
        {
            OnStartLevel?.Invoke();
        }

        public void FireOnGameOver()
        {
            OnGameOver?.Invoke();
        }

        public void FireOnFinishLevel()
        {
            OnFinishLevel?.Invoke();
        }

        public void FireOnDestroyTile()
        {
            OnDestroyTile?.Invoke();
        }

        public void FireOnPrepareLevel(int levelIndex, bool autoMode = false)
        {
            OnPrepareLevel?.Invoke(levelIndex, autoMode);
        }

        public void FireStartSelectedLevel()
        {
            var index = LevelController.Instance.SelectedLevelIndex;
            var playMode = LevelController.Instance.AutoMode;
            FireOnPrepareLevel(index, playMode);
            FireOnStartLevel();
        }

        public void FireOnDestroyFirstTile()
        {
            OnDestroyFirstTile?.Invoke();
        }

        public void FireOnPauseLevel()
        {
            OnPauseLevel?.Invoke();
        }

        public void FireOnReloadLevel()
        {
            OnReloadLevel?.Invoke();
        }

        public LevelData GetLevelData(int indexLevel)
        {
            try
            {
                var levelFile = LevelsContainer.LevelFileName[indexLevel];
                var jsonLevel = levelFile.ToString();
                var levelData = JsonParser.ParseJson(jsonLevel);
                return levelData;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public AudioClip GetAudioClipLevel(int indexLevel)
        {
            try
            {
                return LevelsContainer.LevelsSong[indexLevel];
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public LevelSettings GetLevelSettings(int indexLevel)
        {
            try
            {
                return LevelsContainer.LevelsSettings[indexLevel];
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}