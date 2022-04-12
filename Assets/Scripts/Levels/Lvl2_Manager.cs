using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lvl2_Manager : MonoBehaviour
{
    #region Singilton
    public static Lvl2_Manager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public float speed = .5f;
    public float pressSpeed = 8f;
    public float playerStoppingDilay = 3f;
    public float dlaySpownButtton = .6f;

    public GameObject backgroundSound;

    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;

    public GameObject[] pressButtons;


    bool isPlaying;
    public bool playersCanMove;
    private void Start()
    {
        StartCoroutine(StartGameAfterDilay());
        camera2.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    IEnumerator StartGameAfterDilay()
    {
        yield return new WaitForSeconds(3);
        StartTheGame();
    }
    public void StartTheGame()
    {
        isPlaying = true;
        playersCanMove = true;

        StartCoroutine(CreateNewPressButton());
    }
    void Update()
    {
        if (playersCanMove)
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
    }

    private IEnumerator CreateNewPressButton()
    {
        while (isPlaying)
        {

            GameObject newBtn = Instantiate(pressButtons[Random.Range(0, pressButtons.Length)]);
            newBtn.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(Random.Range(-300, 300), Random.Range(-140, 140));

            yield return new WaitForSeconds(dlaySpownButtton);
        }
    }
    public void LevelCompleted()
    {
        if (isPlaying)
            StartCoroutine(PlayerWin());
    }

    public void LevelField()
    {
        if(isPlaying)
            StartCoroutine(PlayerDead());
    }
    IEnumerator PlayerDead()
    {
        isPlaying = false;

        speed = 3;

        backgroundSound.SetActive(false);

        camera1.SetActive(false);
        camera2.SetActive(true);
        yield return new WaitForSeconds(playerStoppingDilay);
        camera2.SetActive(false);
        camera3.SetActive(true);


        UI_Screens.instance.Lost();


        yield return new WaitForSeconds(playerStoppingDilay/2);
        playersCanMove = false;


    }
    IEnumerator PlayerWin()
    {
        isPlaying = false;

        speed = -3;

        Lvl2_Manager.instance.backgroundSound.SetActive(false);

        camera1.SetActive(false);
        camera3.SetActive(true);

        PlayerPrefs.SetInt(ScenesNames.LVL3, 1);
        UI_Screens.instance.Win();

        yield return new WaitForSeconds(playerStoppingDilay);
        playersCanMove = false;
    }
}
