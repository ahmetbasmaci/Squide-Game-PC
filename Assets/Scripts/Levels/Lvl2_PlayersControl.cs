using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2_PlayersControl : MonoBehaviour
{
    private void Start()
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
        if(Lvl2_Manager.instance.playersCanMove)
            GetComponent<Animator>().SetBool(Anim_Tags.PLAYERS_WALKING, true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.FALLLINE))
        {
            //to cant move
            transform.SetParent(null);

            //applay ragdol
            GetComponent<Animator>().enabled = false;

            foreach (var coll in GetComponentsInChildren<Collider>())
                coll.enabled = true;

            foreach (var chaildRb in GetComponentsInChildren<Rigidbody>())
                chaildRb.useGravity = true;

            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<CapsuleCollider>().enabled = false;


            SoundManager.instance.Play(transform.position, SoundsNames.die);


            if (name==Names.MY_PLAYER)
                Lvl2_Manager.instance.LevelField();

        }
        else if (other.CompareTag(Tags.WINLINE) && name==Names.MY_PLAYER)
        {
            Lvl2_Manager.instance.LevelCompleted();
        }
    }
}
