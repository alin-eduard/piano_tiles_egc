using PianoTilesEGC.Managers;
using UnityEngine;

namespace PianoTilesEGC.Controllers
{
    public class CameraController : IController
    {
        [SerializeField] [Range(0.5f, 10f)]private float cameraSpeed;
        private bool finalLevel;

        public override void OnStartLevel() { }

        public override void OnFinishLevel()
        {
            finalLevel = true;
        }

        public override void OnGameOver()
        {
            finalLevel = true;
        }
        public override void OnDestroyFirstTile()
        {
            Enabled = true; ;
        }

        public override void OnDestroyTile() { }

        public override void OnPrepareLevel(int levelIndex)
        {
            var levelSettings = GameManager.Instance.GetLevelSettings(levelIndex);
            Camera.main.transform.position = levelSettings.StartCameraPosition;
            cameraSpeed = levelSettings.CameraSpeed;
            finalLevel = false;
        }

        private void Update()
        {
            if (Enabled)
            {
                var newPosition = Camera.main.transform.position;

                if (!finalLevel)
                {
                    newPosition.z += cameraSpeed * Time.deltaTime;
                }
                else
                {
                    if (cameraSpeed > 0)
                    {
                        cameraSpeed -= Time.deltaTime;
                        newPosition.z += cameraSpeed * Time.deltaTime;
                    }
                    else
                    {
                        Enabled = false;
                    }
                }

                Camera.main.transform.position = newPosition;
            }
        }
    }
}