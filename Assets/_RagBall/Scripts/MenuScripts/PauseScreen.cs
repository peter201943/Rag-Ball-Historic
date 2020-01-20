using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{

    public Canvas PauseCanvas;
    public Canvas SettingsCanvas;

    void Start()
    {
        Cursor.visible = false;
        PauseCanvas.GetComponent<Canvas>().enabled = false;
        SettingsCanvas.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && PauseCanvas.enabled == false)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            PauseCanvas.GetComponent<Canvas>().enabled = true;
            SettingsCanvas.GetComponent<Canvas>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.P) && PauseCanvas.enabled == true)
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            PauseCanvas.GetComponent<Canvas>().enabled = false;
            SettingsCanvas.GetComponent<Canvas>().enabled = false;
        }
    }  
}
