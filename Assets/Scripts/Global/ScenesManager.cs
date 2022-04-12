using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;

    public GameObject fade_In_Out_Panel;



    GameObject newlevelsTransform_Panel;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        newlevelsTransform_Panel = Instantiate(fade_In_Out_Panel);
    }

    public void LoadNextLevel(string currentLevel)
    {
        string nextLevel = "";

        if (currentLevel == ScenesNames.MAIN)
            nextLevel = ScenesNames.LVL1_TIMELINE;
        else if (currentLevel == ScenesNames.LVL1_TIMELINE)
            nextLevel = ScenesNames.LVL1;
        else if (currentLevel == ScenesNames.LVL1)
            nextLevel = ScenesNames.LVL2_TIMELINE;
        else if (currentLevel == ScenesNames.LVL2_TIMELINE)
            nextLevel = ScenesNames.LVL2;
        else if (currentLevel == ScenesNames.LVL2)
            nextLevel = ScenesNames.LVL3_TIMELINE;
        else if (currentLevel == ScenesNames.LVL3_TIMELINE)
            nextLevel = ScenesNames.LVL3;
        else if (currentLevel == ScenesNames.LVL3)
            nextLevel = ScenesNames.MAIN;


        LoadLevel( nextLevel);
    }

    public void LoadLevel(string levelName)
    {
        newlevelsTransform_Panel.GetComponent<Animator>().SetTrigger(Anim_Tags.FADE_OUT);
        StartCoroutine(LoadNewLevel(levelName));
    }

    IEnumerator LoadNewLevel(string levelName)
    {
        yield return new WaitForSeconds(.6f);


        SceneManager.LoadScene(levelName);
    }
}
