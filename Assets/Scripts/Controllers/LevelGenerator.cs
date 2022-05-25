using System;
using UnityEngine;
using PianoTilesEGC.Utils;
using PianoTilesEGC.DataLevel;
using PianoTilesEGC.Level;

namespace PianoTilesEGC.Controllers
{
    public class LevelGenerator : Singleton<LevelGenerator>
    {
        [Header("Tiles Settings")]
        public GameObject prefabTile;
        public GameObject parentTiles;

        public void GenerateLevel(LevelData levelData, LevelSetings levelSettings)
        {
            for (int i = 0; i < 4; i++)
            {
                var tileDataList = levelData.TilesData[i];
                foreach (var tileData in tileDataList)
                {

                    float offset = levelSettings.DistanceBetweenTiles;

                    switch (tileData.Position.X)
                    {
                        case 0:
                            offset *= -2;
                            break;
                        case 1:
                            offset *= -1;
                            break;
                        case 2:
                            offset *= 1;
                            break;
                        case 3:
                            offset *= 2;
                            break;
                    }

                    var x = levelSettings.Positions[(int)tileData.Position.X] + offset;
                    var z = tileData.Position.Y;
                    var y = 0f;

                    var positionNewTile = new Vector3(x, y, z);
                    GameObject.Instantiate(prefabTile, positionNewTile, new Quaternion(), parentTiles.transform);
                }
            }
        }
    }
}