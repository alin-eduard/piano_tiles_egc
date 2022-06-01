using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;
using PianoTilesEGC.Utils;

namespace PianoTilesEGC.ReaderParserSystem
{
    public static class JsonReader
    {
        public static string ReadJson(string fileName)
        {
            var path = Path.Combine("LevelsData", fileName);
            TextAsset file = Resources.Load(path) as TextAsset;
            string json = file.ToString();
            return json;
        }

        //public static AudioClip ReadAudioClip(string fileName)
        //{
        //    var path = Path.Combine("SongData", fileName);
        //    var audioClip = Resources.Load(path) as AudioClip;
        //    return audioClip;
        //}
    }
}
