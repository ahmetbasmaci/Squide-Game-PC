using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Main_UI_Buttons : MonoBehaviour
{
    public GameObject levelsPanel;

    public bool resetLockMode = false;

    public Button[] levelButtons;


    private void Start()
    {
        levelsPanel.SetActive(false);


        SetLevelsLockMode();

    }
    private void SetLevelsLockMode()
    {
        PlayerPrefs.SetInt(ScenesNames.LVL1, 1);
        if (resetLockMode)
        {
            PlayerPrefs.SetInt(ScenesNames.LVL2, 0);
            PlayerPrefs.SetInt(ScenesNames.LVL3, 0);
        }


        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].GetComponent<Button>().interactable = Convert.ToBoolean(PlayerPrefs.GetInt("lvl" + (i + 1), 0));
        }

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ShowlevelsPanel()
    {
        levelsPanel.SetActive(true);
    }

    public void HidelevelsPanel()
    {
        levelsPanel.SetActive(false);
    }


    public void LoadLevel_1()
    {
        ScenesManager.instance.LoadLevel(ScenesNames.LVL1_TIMELINE);
    }

    public void LoadLevel_2()
    {
        ScenesManager.instance.LoadLevel(ScenesNames.LVL2);
    }


}
