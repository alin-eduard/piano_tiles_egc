using PianoTilesEGC.Utils;
using PianoTilesEGC.Managers;
using PianoTilesEGC.DataLevel;
using PianoTilesEGC.ReaderParserSystem;
using UnityEngine;
using System;
using PianoTilesEGC.Level;

namespace PianoTilesEGC.Controllers
{
    public class LevelController : Singleton<LevelController>
    {
        public void PlayLevel(int indexLevel)
        {
            var levelData = GetLevelData(indexLevel);
            //var levelAudioClio = GetAudioClipLevel(indexLevel);
            var levelSettings = GameManeger.Instance.LevelsContainer.LevelsSettings;

            LevelGenerator.Instance.GenerateLevel(levelData, levelSettings);
        }

        private LevelData GetLevelData(int indexLevel)
        {
            try
            {
                var levelFileName = GameManeger.Instance.LevelsContainer.LevelFileName[indexLevel];
                var jsonLevel = JsonReader.ReadJson(levelFileName);
                var levelData = JsonParser.ParseJson(jsonLevel);
                return levelData;
            }
            catch (Exception exception)
            {
                Debug.LogError(exception.ToString());
                return null;
            }
        }

        private AudioClip GetAudioClipLevel(int indexLevel)
        {
            try
            {
                return GameManeger.Instance.LevelsContainer.LevelsSong[indexLevel];
            }
            catch (Exception exception)
            {
                Debug.LogError(exception.ToString());
                return null;
            }
        }
    }
}