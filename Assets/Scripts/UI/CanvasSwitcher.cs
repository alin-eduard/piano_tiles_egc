using UnityEngine;
using UnityEngine.UI;
using PianoTilesEGC.Utils;
using PianoTilesEGC.Managers;
using System.Collections.Generic;

[RequireComponent(typeof(Button))]
public class CanvasSwitcher : MonoBehaviour
{
    public CanvasType desiredCanvasType;
    private Button menuButton;

    public void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        UIManager.Instance.SwitchCanvas(desiredCanvasType);
    }
}
