using System;
using UnityEngine;
using UnityEngine.UI;
using PianoTilesEGC.Level;
using PianoTilesEGC.Utils;

namespace PianoTilesEGC.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private LevelsContainer levelsContainer;
        public LevelsContainer LevelsContainer => levelsContainer;

        public Action OnStartLevel;
        public Action OnGameOver;
        public Action OnFinishLevel;
        public Action OnDestroyTile;
        public Action<int> OnPrepareLevel;


        // testing
        public Button TestButton;

        private void Start()
        {
            FireOnPrepareLevel(0);
            TestButton.onClick.AddListener(delegate 
            {
                FireOnStartLevel();
                TestButton.gameObject.SetActive(false);
            });
        }
        //-------

        public void FireOnStartLevel()
        {
            OnStartLevel?.Invoke();
        }

        public void FireOnGameOver()
        {
            OnGameOver?.Invoke();
        }

        public void FireOnFinishLevel()
        {
            OnFinishLevel?.Invoke();
        }

        public void FireOnDestroyTile()
        {
            OnDestroyTile?.Invoke();
        }  
        
        public void FireOnPrepareLevel(int levelIndex)
        {
            OnPrepareLevel?.Invoke(levelIndex);
        }
    }
}
