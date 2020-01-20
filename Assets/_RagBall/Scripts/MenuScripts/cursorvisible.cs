using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorvisible : MonoBehaviour
{
    public bool CursorOn;

    void Start()
    {
        Cursor.visible = CursorOn;
    }


}
