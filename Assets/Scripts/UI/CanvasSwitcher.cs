using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

[RequireComponent(typeof(Button))]
public class CanvasSwitcher : MonoBehaviour
{
    public CanvasType desiredCanvasType;

    UIManager canvasManager;
    Button menuButton;

    // Start is called before the first frame update
    public void Start()
    {
        menuButton = GetComponent<Button>();
        menuButton.onClick.AddListener(OnButtonClicked);
        canvasManager = UIManager.GetInstance();

    }


    void OnButtonClicked()
    {
        canvasManager.SwitchCanvas(desiredCanvasType);
    }
}
