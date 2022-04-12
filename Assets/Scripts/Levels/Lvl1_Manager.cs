using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lvl1_Manager : MonoBehaviour
{
    #region Singelton
    public static Lvl1_Manager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public int roundTime = 60;
    public int currentRound = 1;

    [Space(10)]
    [Header("References")]
    public GameObject MyPlayer;

    void Start()
    {
        StartCoroutine(DecreaseTime());

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void LevelField()
    {
        UI_Screens.instance.Lost();

        StartCoroutine(FixTimeScale());
    }
    IEnumerator FixTimeScale()
    {
        yield return new WaitForSeconds(.5f);
        Time.timeScale = 1;

    }

    public void LevelCompleted()
    {
        PlayerPrefs.SetInt(ScenesNames.LVL2, 1);

        UI_Screens.instance.Win();
    }
    IEnumerator DecreaseTime()
    {
        while (roundTime>0)
        {
            roundTime--;
            yield return new WaitForSeconds(1);
        }

        EndTheRound();
    }

    private void EndTheRound()
    {
        EnemyGilrControl.instance.KillAllPlayers();
    }
}
