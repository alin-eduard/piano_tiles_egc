using Newtonsoft.Json;
using PianoTilesEGC.DataLevel;

namespace PianoTilesEGC.ReaderParserSystem
{
    public static class JsonParser
    {
        public static LevelData ParseJson(string json)
        {
            LevelData levelData = JsonConvert.DeserializeObject<DataLevel.LevelData>(json);
            return levelData;
        }
    }
}
