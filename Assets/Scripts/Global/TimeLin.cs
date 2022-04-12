using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLin : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void TimeLineEnded()
    {
        ScenesManager.instance.LoadNextLevel(SceneManager.GetActiveScene().name);
    }
}
