using UnityEngine;
using PianoTilesEGC.Utils;
using PianoTilesEGC.Managers;

namespace PianoTilesEGC.Controllers
{
    public class DeathZoneController : IController<DeathZoneController>
    {
        [SerializeField] private bool AutoDestroy = false;

        public override void OnDestroyTile()
        {
        }

        public override void OnFinishLevel()
        {
        }

        public override void OnGameOver()
        {
        }

        public override void OnPrepareLevel(int levelIndex, bool autoMode = false)
        {
        }

        public override void OnStartLevel()
        {
        }

        public override void OnDestroyFirstTile()
        {
        }

        public override void OnPauseLevel()
        {
        }

        public override void OnReloadLevel()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag.Equals(Constants.Tags.Tile))
            {
                if (!AutoDestroy)
                {
                    GameManager.Instance.FireOnGameOver();
                }
                else
                {
                    Destroy(other.gameObject);
                    GameManager.Instance.FireOnDestroyTile();
                }
            }
        }
    }
}