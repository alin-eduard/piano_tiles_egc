using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void Exit()
    {
        //when building the game comment the next line
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
