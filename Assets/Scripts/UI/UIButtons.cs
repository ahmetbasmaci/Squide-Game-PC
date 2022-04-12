using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{

    public void RelodeLevel()
    {
        ScenesManager.instance.LoadLevel(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        ScenesManager.instance.LoadNextLevel(SceneManager.GetActiveScene().name);
    }
    public void GoToMain()
    {
        ScenesManager.instance.LoadLevel(ScenesNames.MAIN);
    }
}
