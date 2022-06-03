using UnityEngine;
using PianoTilesEGC.Controllers;

namespace PianoTilesEGC
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] private int LevelIndex;
        [SerializeField] private bool AutoPlayMode;
        
        public void SelectLevel()
        {
            LevelController.Instance.SelectedLevelIndex = LevelIndex;
            LevelController.Instance.AutoMode = AutoPlayMode;
        }
    }
}
