using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PianoTilesEGC.Level
{
    [CreateAssetMenu(fileName = "Level Setings", menuName = "ScriptableObjects/Level Settings", order = 1)]

    public class LevelSettings : ScriptableObject
    {
        [Range(0, 1)] public float DistanceBetweenTiles = 0.1f;
        [Range(0.5f, 10)]  public float TileLength = 1;
        [Range(0.5f, 10)]  public float CameraSpeed = 1; 
        public Vector3 StartCameraPosition = new Vector3(0, 5, -1.5f);
        public List<float> Positions = new List<float>();
    }
}
