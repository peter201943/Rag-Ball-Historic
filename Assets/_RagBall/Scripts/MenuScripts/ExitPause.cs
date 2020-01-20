using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExitPause : MonoBehaviour
{
    public Canvas PauseCanvas;

    

    public void FixedUpdate()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
            return;


    }

    public void ButtonPush()
    {
        var gamepad = Gamepad.current;

        if (gamepad.selectButton.wasPressedThisFrame)
        {
        Debug.Log("Shoot");
        Time.timeScale = 1f;
        Cursor.visible = false;
        PauseCanvas.GetComponent<Canvas>().enabled = false;
        }
    }
        
    /*public void OnMouseUp()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        PauseCanvas.GetComponent<Canvas>().enabled = false;
    }*/
}
