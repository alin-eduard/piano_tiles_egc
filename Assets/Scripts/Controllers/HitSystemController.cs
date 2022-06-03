using UnityEngine;
using PianoTilesEGC.Utils;
using PianoTilesEGC.Managers;
using System.Collections;

namespace PianoTilesEGC.Controllers
{
    public class HitSystemController : IController<HitSystemController>
    {
        public override void OnStartLevel()
        {
            StartCoroutine(DelayEnable(0.5f));
        }

        public override void OnFinishLevel()
        {
            Enabled = false;
        }

        public override void OnGameOver()
        {
            Enabled = false;
        }

        public override void OnDestroyFirstTile() { }
        
        public override void OnDestroyTile() { }

        public override void OnPrepareLevel(int levelIndex, bool autoMode = false) { }

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

        private IEnumerator DelayEnable(float delay)
        {
            yield return new WaitForSeconds(delay);
            Enabled = true;
        }
    }
}
