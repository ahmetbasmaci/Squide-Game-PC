using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;

    public GameObject levelsTransform_Panel;


    GameObject newlevelsTransform_Panel;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        newlevelsTransform_Panel = Instantiate(levelsTransform_Panel);
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
