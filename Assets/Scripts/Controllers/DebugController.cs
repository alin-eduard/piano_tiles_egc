using UnityEngine;

namespace PianoTilesEGC.Controllers
{
    public class DebugController : IController
    {
        public override void OnStartLevel()
        {
            Debug.Log("<color=#00FF00> Start Level </color>");
        }

        public override void OnGameOver()
        {
            Debug.Log("<color=#FF0000> Game Over </color>");
        }

        public override void OnFinishLevel()
        {
            Debug.Log("<color=#00FF00> Finish Level </color>");
        }

        public override void OnDestroyTile()
        {
            Debug.Log("<color=#00FFFF> Destroy Tile </color>");
        }

        public override void OnPrepareLevel(int levelIndex)
        {
            Debug.Log("<color=#FFFF00> Prepare Level -> Index: " + levelIndex + "</color>");
        }
    }
}
