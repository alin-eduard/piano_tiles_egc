using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PianoTilesEGC.Level
{
    [CreateAssetMenu(fileName = "Level Setings", menuName = "ScriptableObjects/Level Settings", order = 1)]

    public class LevelSetings : ScriptableObject
    {
        [Range(0, 1)] public float DistanceBetweenTiles = 0.1f;
        [Range(0.5f, 10)]  public float TileLength = 1;
        public List<float> Positions = new List<float>();
    }
}
