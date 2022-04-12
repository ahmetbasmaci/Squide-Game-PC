using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1_PlayersManager : MonoBehaviour
{

    public bool isDead = false;
    public bool isWon = false;
    public bool isStarted = false;


    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        foreach (var chailRb in GetComponentsInChildren<Rigidbody>())
            chailRb.useGravity = false;

        foreach (var coll in GetComponentsInChildren<Collider>())
            coll.enabled = false;

        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;


    }
    private void Update()
    {
        anim.SetBool(Anim_Tags.PLAYERS_RUNNING, GetComponent<Lvl1_PlayersMovement>().isRunning);
    }
    private void PlayerWon()
    {
        isWon = true;
        tag = Tags.PLAYERS_DEAD;

        for (int i = 0; i < 45; i++)
        {

            Vector3 newPosition = Vector3.forward * Time.deltaTime;
            transform.Translate(newPosition, Space.Self);
        }

        GetComponent<Lvl1_PlayersMovement>().isRunning = false;

        anim.SetInteger(Anim_Tags.PLAYERS_VECTORY, Random.Range(1, 9));
    }

    public void Dead()
    {
        if (isDead) return;

        //SoundManager.instance.Play(transform.position, SoundsNames.die);

        isDead = true;
        anim.enabled = false;
        tag = Tags.PLAYERS_DEAD;


        foreach (var coll in GetComponentsInChildren<Collider>())
            coll.enabled = true;

        foreach (var chailRb in GetComponentsInChildren<Rigidbody>())
            chailRb.useGravity = true;

        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<CapsuleCollider>().enabled = false;

    }//Dead
    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag(Tags.STARTLINE))
        {
            isStarted = true;
        }
        else if (other.CompareTag(Tags.WINLINE))
        {
            PlayerWon();
        }
    }
}
