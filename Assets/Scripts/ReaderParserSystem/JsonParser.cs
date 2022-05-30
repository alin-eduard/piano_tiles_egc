using Newtonsoft.Json;
using PianoTilesEGC.LevelData;
using UnityEngine;
using PianoTilesEGC.Utils;

namespace PianoTilesEGC.ReaderParserSystem
{
    public class JsonParser : Singleton<JsonParser>
    {
        public LevelData.LevelData ParseJson(string json)
        {
            LevelData.LevelData levelData = JsonConvert.DeserializeObject<LevelData.LevelData>(json);
            return levelData;
        }
    }
}
