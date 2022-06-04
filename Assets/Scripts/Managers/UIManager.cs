using UnityEngine;
using System.Linq;
using PianoTilesEGC.Utils;
using System.Collections.Generic;
using PianoTilesEGC.UI;
using PianoTilesEGC.Controllers;
using System;

namespace PianoTilesEGC.Managers
{
    public class UIManager : Singleton<UIManager>
    {
        List<UIState> UIControllersList;
        UIState lastActiveCanvas;

        protected override void Awake()
        {
            base.Awake();
            UIControllersList = GetComponentsInChildren<UIState>().ToList();

            UIControllersList.ForEach(x => x.gameObject.SetActive(false));

            SwitchCanvas(CanvasType.MainMenu);
        }

        public void SwitchCanvas(CanvasType _type)
        {
            if (lastActiveCanvas != null)
            {
                lastActiveCanvas.gameObject.SetActive(false);
            }

            UIState desiredCanvas = UIControllersList.Find(x => x.canvasType == _type);
            if (desiredCanvas != null)
            {
                desiredCanvas.gameObject.SetActive(true);
                lastActiveCanvas = desiredCanvas;

                var index = LevelController.Instance.SelectedLevelIndex;
                var playMode = LevelController.Instance.AutoMode;

                switch (_type)
                {
                    case CanvasType.GameUI:
                        GameManager.Instance.FireOnPrepareLevel(index, playMode);
                        GameManager.Instance.FireOnStartLevel();
                        break;
                }
            }
            else
            {
                Debug.LogWarning("The desired canvas was not found!");
            }
        }

    }
}