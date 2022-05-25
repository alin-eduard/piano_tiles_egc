using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;
using PianoTilesEGC.Utils;

namespace PianoTilesEGC.ReaderParserSystem
{
    public static class JsonReader
    {
        static string path = Application.streamingAssetsPath + "/Resources/LevelsData/";
        
        public static string ReadJson(string fileName)
        { 
            using (var sr = new StreamReader(path + fileName + ".json"))
            {
                string json = sr.ReadToEnd();;
                return json;
            }
        }
    }
}
