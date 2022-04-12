using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGilrControl : MonoBehaviour
{
    public static EnemyGilrControl instance;


    [Space(10)]
    public float hidingTime = 8f;
    public float lookingTime = 5f;
    public float fireDilay = .3f;


    [Space]
    [Header("Referensec")]
    public GameObject[] blood_Effect;
    public GameObject deathBlood;

    [HideInInspector] public bool isLooking = false;

     public List<GameObject> playersToKill = new List<GameObject>();
    Animator anim;
    void Awake()
    {
        if (instance == null)
            instance = this;


        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(TurnAround());


    }

    void Update()
    {
        if (isLooking)
            CheckToKill_MyPlayer();

    }
    bool playerWillDie = false;
    private void CheckToKill_MyPlayer()
    {
        if (playerWillDie) return;

       if (Lvl1_Manager.instance.MyPlayer.GetComponent<CharacterController>().velocity.magnitude > 0.1f
            && !Lvl1_Manager.instance.MyPlayer.GetComponent<Lvl1_MyPlayer>().isWon
            && !Lvl1_Manager.instance.MyPlayer.GetComponent<Lvl1_MyPlayer>().isDead
            && Lvl1_Manager.instance.MyPlayer.GetComponent<Lvl1_MyPlayer>().isStarted)
       {
            playerWillDie = true;

            playersToKill.Add(Lvl1_Manager.instance.MyPlayer);


            //StopCoroutine(KillMovingPlayers());
            StartCoroutine(KillMovingPlayers());
            
       }
    }

    private void CheckToKill_Players()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(Tags.PLAYERS);
        foreach (var player in players)
        {
            if (player.GetComponent<Lvl1_PlayersMovement>().isRunning && player.GetComponent<Lvl1_PlayersManager>().isStarted)
                playersToKill.Add(player);    
        }
        if(playersToKill.Count>0)
            StartCoroutine(KillMovingPlayers());
    }

    public void KillAllPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(Tags.PLAYERS);
        foreach (var player in players)
                playersToKill.Add(player);

        if (!Lvl1_Manager.instance.MyPlayer.GetComponent<Lvl1_MyPlayer>().isWon)
            playersToKill.Add(Lvl1_Manager.instance.MyPlayer);

        StartCoroutine(KillMovingPlayers());
    }
    IEnumerator KillMovingPlayers()
    {
        int lenght = playersToKill.Count - 1;
        for (int i = lenght; i >=0 ; i--)
        {
            yield return new WaitForSeconds(fireDilay);
            Vector3 newPos = new Vector3(playersToKill[i].transform.position.x, playersToKill[i].transform.position.y + 1.3f, playersToKill[i].transform.position.z);


            GameObject newBlood = Instantiate(blood_Effect[0], newPos, Quaternion.identity);
            newBlood.transform.SetParent(playersToKill[i].transform);
            newPos.y = .8f;
            newBlood = Instantiate(blood_Effect[1], newPos, Quaternion.identity);
            newBlood.transform.SetParent(playersToKill[i].transform);

            GameObject newBloodProjector = Instantiate(deathBlood, new Vector3(playersToKill[i].transform.position.x, playersToKill[i].transform.position.y + 0.012f, playersToKill[i].transform.position.z), Quaternion.Euler(90, 0, 0));
            newBloodProjector.transform.SetParent(playersToKill[i].transform);

            if (playersToKill[i].name == Names.MY_PLAYER)
                playersToKill[i].GetComponent<Lvl1_MyPlayer>().Dead();
            else
                playersToKill[i].GetComponent<Lvl1_PlayersManager>().Dead();

            SoundManager.instance.Play(transform.position, SoundsNames.rifleFire);
            playersToKill.Remove(playersToKill[i]);
            yield return new WaitForSeconds(fireDilay);
        }

    }

    IEnumerator TurnAround()
    {
        while (!Lvl1_Manager.instance.MyPlayer.GetComponent<Lvl1_MyPlayer>().isWon)
        {
            SoundManager.instance.Play(transform.position, SoundsNames.enemyGirl_bokuva, 1 / (hidingTime / 4.5f));
            
            yield return new WaitForSeconds(hidingTime);

            anim.SetTrigger(Anim_Tags.GirlEnemyTurnForwerd_Trigger);

            isLooking = true;

            yield return new WaitForSeconds(.2f);
            
            CheckToKill_Players();

            SoundManager.instance.Play(transform.position, SoundsNames.enemyGirl_robot, 1 / (lookingTime / 2.5f));

            yield return new WaitForSeconds(lookingTime);

            anim.SetTrigger(Anim_Tags.GirlEnemyTurnBack_Trigger);
            isLooking = false;
            Lvl1_Manager.instance.currentRound++;

            if (hidingTime > 2)
            {
                hidingTime -= 0.5f;
            }
        }

        isLooking = false;
    }




}
