using UnityEngine;

namespace PianoTilesEGC.Controllers
{
    public class CameraController : IController
    {
        private float cameraSpeed = 1.0f;
        private float smoothStopDuration = 2f;
        private Vector3 defaultCameraPosition;

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

        public override void OnPrepareLevel(int levelIndex)
        {
            Camera.main.transform.position = defaultCameraPosition;
        }

        private void Start()
        {
            defaultCameraPosition = Camera.main.transform.position;
        }

        private void Update()
        {
            if (Enabled)
            {
                var newPosition = Camera.main.transform.position;
                newPosition.z += cameraSpeed * Time.deltaTime;
                Camera.main.transform.position = newPosition;
            }
        }
    }
}