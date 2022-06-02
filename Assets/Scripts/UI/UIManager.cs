using PianoTilesEGC.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public enum CanvasType
{
    MainMenu,
    GameUI,
    HowToPlay,
    LevelSelector,
    GameOver
}
public class UIManager : Singleton<UIManager>
{
    List<UIController> UIControllersList;
    UIController lastActiveCanvas;

     protected override void Awake()
     {
         base.Awake();
         UIControllersList = GetComponentsInChildren<UIController>().ToList();

         UIControllersList.ForEach(x => x.gameObject.SetActive(false));

         SwitchCanvas(CanvasType.MainMenu);

     }

     public void SwitchCanvas(CanvasType _type)
     {
         if(lastActiveCanvas != null)
         {
             lastActiveCanvas.gameObject.SetActive(false);
         }

         UIController desiredCanvas = UIControllersList.Find(x => x.canvasType == _type);
         if (desiredCanvas != null)
         {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
         else { Debug.LogWarning("The desired canvas was not found!"); }
     }
    
}
