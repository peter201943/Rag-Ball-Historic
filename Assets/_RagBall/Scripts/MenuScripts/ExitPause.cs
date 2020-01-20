using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPause : MonoBehaviour
{
    public Canvas PauseCanvas;

    public void OnMouseUp()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        PauseCanvas.GetComponent<Canvas>().enabled = false;
    }
}
