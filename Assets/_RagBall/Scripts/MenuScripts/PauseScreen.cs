using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    void FixedUpdate()
    {

        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;

        if (gamepad.startButton.wasPressedThisFrame && PauseCanvas.enabled == false)
        {
            Time.timeScale = 0f;
            PauseCanvas.GetComponent<Canvas>().enabled = true;
            SettingsCanvas.GetComponent<Canvas>().enabled = false;
        }

        /*if (gamepad.bButton.wasPressedThisFrame)
        {
            Debug.Log("Shoot");
            Time.timeScale = 1f;
            PauseCanvas.GetComponent<Canvas>().enabled = false;
            SettingsCanvas.GetComponent<Canvas>().enabled = false;
        }*/
    }
}
