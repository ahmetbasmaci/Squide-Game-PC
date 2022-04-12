using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Screens : MonoBehaviour
{
    #region Singilton
    public static UI_Screens instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    [Space(10)]
    [Header("Screens")]
    [SerializeField] GameObject death_Screen;
    [SerializeField] GameObject win_Screen;
    [SerializeField] GameObject menu_Screen;



    GameObject curreent_winScreen;
    GameObject curreent_deathScreen;
    GameObject curreent_menuScreen;
    private void Start()
    {
        CreateAndDeactiveScreens();
    }

    private void Update()
    {
        CheckPauseTheGame();
    }

    private void CheckPauseTheGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (curreent_menuScreen.activeInHierarchy)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;


                Time.timeScale = 1;

                curreent_menuScreen.SetActive(false);
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                Time.timeScale = 0;

                curreent_menuScreen.SetActive(true);
            }
        }
    }

    private void CreateAndDeactiveScreens()
    {
        curreent_winScreen = Instantiate(win_Screen);
        curreent_winScreen.SetActive(false);


        curreent_deathScreen = Instantiate(death_Screen);
        curreent_deathScreen.SetActive(false);

        curreent_menuScreen = Instantiate(menu_Screen);
        curreent_menuScreen.SetActive(false);
    }   

    public void Lost()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        curreent_deathScreen.SetActive(true);
    }
    public void Win()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        curreent_winScreen.SetActive(true);
    }
}
