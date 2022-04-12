using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lvl1_UI : MonoBehaviour
{
    #region Singelton
    public static Lvl1_UI instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion


    [Header("UI")]
    public TextMeshProUGUI txt_Round;
    public TextMeshProUGUI txt_time;
    public Image img_lookingTimr;
    public Image img_hidingTimr;




    float spendedOfLookingTime = 0;
    float spendedOfHidingTime = 0;
    private void Start()
    {
        spendedOfHidingTime = EnemyGilrControl.instance.hidingTime;


    }

    private void Update()
    {
        SetTextsValues();


        CheckHidingLookingImage();

    }

    private void CheckHidingLookingImage()
    {
        if (!EnemyGilrControl.instance.isLooking)
        {
            spendedOfLookingTime = EnemyGilrControl.instance.lookingTime;
            img_lookingTimr.enabled = false;

            img_hidingTimr.enabled = true;
            spendedOfHidingTime-=Time.deltaTime;
            img_hidingTimr.fillAmount = spendedOfHidingTime / EnemyGilrControl.instance.hidingTime;

        }
        else
        {
            spendedOfHidingTime = EnemyGilrControl.instance.hidingTime;
            img_hidingTimr.enabled = false;

            spendedOfLookingTime -= Time.deltaTime;
            img_lookingTimr.enabled = true;
            img_lookingTimr.fillAmount =(float) spendedOfLookingTime /(float) EnemyGilrControl.instance.lookingTime;

        }

    }

    private void SetTextsValues()
    {
        txt_Round.text = Lvl1_Manager.instance.currentRound.ToString();
        txt_time.text = Lvl1_Manager.instance.roundTime.ToString();

    }


}
