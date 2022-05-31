using UnityEngine;
using PianoTilesEGC.Utils;
using PianoTilesEGC.Managers;

namespace PianoTilesEGC.Controllers
{
    public class HitController : IController
    {
        public override void OnStartLevel()
        {
            Enabled = true;
        }

        public override void OnFinishLevel()
        {
            Enabled = false;
        }

        public override void OnGameOver()
        {
            Enabled = false;
        }

        public override void OnDestroyTile() { }

        public override void OnPrepareLevel(int levelIndex) { }

        void Update()
        {
            if (Enabled && Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    var hitGameObject = hit.collider.gameObject;
                    if (hitGameObject.transform.parent.tag.Equals(Constants.Tags.Tile))
                    {
                        Destroy(hitGameObject.transform.parent.gameObject);
                        GameManager.Instance.FireOnDestroyTile();
                    }
                }
            }
        }
    }
}
