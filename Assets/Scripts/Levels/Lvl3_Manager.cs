using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;
using Cinemachine;

public class Lvl3_Manager : MonoBehaviour
{
    #region Singilton
    public static Lvl3_Manager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    [Header("UI")]
    public int lives = 5;
    public TextMeshProUGUI txt_lives;

    [Header("Listes")]
    public List<GlassSameLine> all_glases;
    public List<GameObject> players;
    
    [Header("References")]
    public GameObject playerFollowCam;
    public GameObject backgroundSound;
    public GameObject lastPositionCamera;

    GameObject currentPlayer;
    GameObject currentCam2;

    bool gameEnded;
    void Start()
    {
        lives = players.Count;

        SetRandomBrokableGlass();

        SetStarterPlayer();
    }

    private void SetStarterPlayer()
    {
        for (int i = 1; i < players.Count; i++)
        {
            players[i].GetComponent<CapsuleCollider>().enabled = false;
            players[i].GetComponent<PlayerInput>().enabled = false;
        }
        currentPlayer = players[0];

        txt_lives.text = lives.ToString();
    }

    private void SetRandomBrokableGlass()
    {
        int randomBrokenGlas = 0;
        foreach (var item in all_glases)
        {
            randomBrokenGlas = Random.Range(1, 3);
            GameObject brokenGlass;

            if (randomBrokenGlas == 1)
                brokenGlass = item.glases1;
            else
                brokenGlass = item.glases2;

            brokenGlass.GetComponent<BreakableWindow>().useCollision = false;
        }
    }
    public void PlayerFalling(GameObject newCam2)
    {
        lives--;
        txt_lives.text = lives.ToString();

        SetRagdolToPlayer();

        currentCam2 = newCam2;
        currentCam2.SetActive(true);

    }
    public void PlayerOnGround()
    {


        if (lives > 0)
            StartCoroutine(EnableNewPlayer());
        else
            StartCoroutine(LevelField());
    }
    private void SetRagdolToPlayer()
    {
        //set ragdol
        foreach (var chailRb in currentPlayer.GetComponentsInChildren<Rigidbody>())
            chailRb.useGravity = true;

        foreach (var coll in currentPlayer.GetComponentsInChildren<Collider>())
            coll.enabled = true;

        //disable old player
        currentPlayer.GetComponent<CharacterController>().enabled = false;
        currentPlayer.GetComponent<ThirdPersonController>().enabled = false;
        currentPlayer.GetComponent<PlayerInput>().enabled = false;
        currentPlayer.GetComponent<Animator>().enabled = false;

        players.Remove(currentPlayer);
    }

    IEnumerator EnableNewPlayer()
    {
        yield return new WaitForSeconds(.5f);

        currentCam2.SetActive(false);

        //set new player
        currentPlayer = players[0];
        currentPlayer.GetComponent<CharacterController>().enabled = true;
        currentPlayer.GetComponent<PlayerInput>().enabled = true;
        currentPlayer.GetComponent<ThirdPersonController>().enabled = true;
        currentPlayer.GetComponent<CapsuleCollider>().enabled = true;

        playerFollowCam.GetComponent<CinemachineVirtualCamera>().Follow = currentPlayer.transform.GetChild(0);
    }

    public IEnumerator LevelField()
    {
        if (!gameEnded)
        {
            gameEnded = true;
            yield return new WaitForSeconds(1f);

            backgroundSound.SetActive(false);

            UI_Screens.instance.Lost();

            Camera.main.gameObject.SetActive(false);
            lastPositionCamera.SetActive(true);


        }
    }

    public void LevelCompeted()
    {
        PlayerPrefs.SetInt(ScenesNames.LVL4, 1);
        UI_Screens.instance.Win();
    }

}



[System.Serializable]
public class GlassSameLine
{
    public GameObject glases1;
    public GameObject glases2;
}