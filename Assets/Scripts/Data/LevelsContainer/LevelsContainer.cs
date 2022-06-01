using System;
using System.Collections.Generic;
using UnityEngine;

namespace PianoTilesEGC.Level
{
    [CreateAssetMenu(fileName = "Levels Container", menuName = "ScriptableObjects/Levels Container", order = 1)]
    public class LevelsContainer : ScriptableObject
    {
        public List<TextAsset> LevelFileName = new List<TextAsset>();
        public List<AudioClip> LevelsSong = new List<AudioClip>();
        public List<LevelSettings> LevelsSettings = new List<LevelSettings>();
    }
}