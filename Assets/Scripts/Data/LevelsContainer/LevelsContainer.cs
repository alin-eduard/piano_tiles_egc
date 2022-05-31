using System;
using System.Collections.Generic;
using UnityEngine;

namespace PianoTilesEGC.Level
{
    [CreateAssetMenu(fileName = "Levels Container", menuName = "ScriptableObjects/Levels Container", order = 1)]
    public class LevelsContainer : ScriptableObject
    {
        public List<string> LevelFileName = new List<string>();
        public List<AudioClip> LevelsSong = new List<AudioClip>();
        public List<LevelSettings> LevelsSettings = new List<LevelSettings>();
    }
}