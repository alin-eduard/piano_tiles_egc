using UnityEngine;
using PianoTilesEGC.Utils;
using PianoTilesEGC.Managers;

namespace PianoTilesEGC.Controllers
{
    public class DeathZoneController : IController
    {
        public override void OnDestroyTile() { }

        public override void OnFinishLevel() { }

        public override void OnGameOver() { }

        public override void OnPrepareLevel(int levelIndex) { }

        public override void OnStartLevel() { }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals(Constants.Tags.Tile))
            {
                GameManager.Instance.FireOnGameOver();
            }
        }
    }
}
