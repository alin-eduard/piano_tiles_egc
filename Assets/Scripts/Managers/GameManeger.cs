using UnityEngine;
using PianoTilesEGC.Level;
using PianoTilesEGC.Utils;
using PianoTilesEGC.Controllers;

namespace PianoTilesEGC.Managers
{
    public class GameManeger : Singleton<GameManeger>
    {
        [SerializeField] private LevelsContainer levelsContainer;
        public LevelsContainer LevelsContainer
        {
            get => levelsContainer;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var indexLevel = 0;
                LevelController.Instance.PlayLevel(indexLevel);
            }
        }
    }
}
