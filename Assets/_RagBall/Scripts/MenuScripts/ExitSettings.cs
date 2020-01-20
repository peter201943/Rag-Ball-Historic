using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSettings : MonoBehaviour
{
    public Canvas PauseCanvas;
    public Canvas SettingsCanvas;

    public void OnMouseUp()
    {
        PauseCanvas.GetComponent<Canvas>().enabled = true;
        SettingsCanvas.GetComponent<Canvas>().enabled = false;
    }
}
