using PianoTilesEGC.Utils;
using PianoTilesEGC.Managers;
using System.Collections.Generic;

namespace PianoTilesEGC.Controllers
{
    public class UIController : IController<UIController>
    {
        public override void OnStartLevel() { }

        public override void OnGameOver() 
        {
            UIManager.Instance.SwitchCanvas(CanvasType.GameOver);
        }

        public override void OnFinishLevel() 
        {
            UIManager.Instance.SwitchCanvas(CanvasType.FinishedGame);
        }

        public override void OnDestroyTile() { }

        public override void OnPrepareLevel(int levelIndex, bool autoMode = false) { }
        
        public override void OnDestroyFirstTile() { }

    }
}
