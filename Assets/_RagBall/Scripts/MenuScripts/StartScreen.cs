using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    void Update()
{
    if (Input.GetKey(KeyCode.Escape))
    {
        SceneManager.LoadScene(0);
    }
}
}
