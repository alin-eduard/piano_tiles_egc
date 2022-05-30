using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;
using PianoTilesEGC.Utils;

namespace PianoTilesEGC.ReaderParserSystem
{
    public class JsonReader : Singleton<JsonReader>
    {
        static string path = Application.streamingAssetsPath + "Resources/LevelsData";
        
        public string ReadJson(string fileName)
        { 
            using (var sr = new StreamReader(path + fileName))
            {
                string json = sr.ReadToEnd();;
                return json;
            }
        }
    }
}
