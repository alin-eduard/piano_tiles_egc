using PianoTilesEGC.Utils;
using PianoTilesEGC.Managers;

namespace PianoTilesEGC.Controllers
{
    public abstract class IController<T> : Singleton<T> where T : Singleton<T>
    {
        public bool Enabled = false;

        private void Awake()
        {
            GameManager.Instance.OnStartLevel += OnStartLevel;
            GameManager.Instance.OnFinishLevel += OnFinishLevel;
            GameManager.Instance.OnGameOver += OnGameOver;
            GameManager.Instance.OnDestroyTile += OnDestroyTile;
            GameManager.Instance.OnPrepareLevel += OnPrepareLevel;
            GameManager.Instance.OnDestroyFirstTile += OnDestroyFirstTile;
            GameManager.Instance.OnPauseLevel += OnPauseLevel;
            GameManager.Instance.OnReloadLevel += OnReloadLevel;
        }

        public abstract void OnStartLevel();
        public abstract void OnFinishLevel();
        public abstract void OnGameOver();
        public abstract void OnDestroyTile();
        public abstract void OnPauseLevel();
        public abstract void OnReloadLevel();
        public abstract void OnDestroyFirstTile();
        public abstract void OnPrepareLevel(int levelIndex, bool autoMode = false);
    }
}