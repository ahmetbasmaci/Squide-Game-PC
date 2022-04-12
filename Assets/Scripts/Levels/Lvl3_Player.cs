using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;
using System;

public class Lvl3_Player : MonoBehaviour
{
    public GameObject camera2;
    void Start()
    {
        foreach (var chailRb in GetComponentsInChildren<Rigidbody>())
            chailRb.useGravity = false;

        foreach (var coll in GetComponentsInChildren<Collider>())
            coll.enabled = false;

        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.FALLLINE))
        {
            Lvl3_Manager.instance.PlayerFalling(camera2);
        }
        else if (other.CompareTag(Tags.WINLINE))
        {
            Lvl3_Manager.instance.LevelCompeted();
            StartCoroutine(ChangeTriggerMode(other));
        }
    }
    IEnumerator ChangeTriggerMode(Collider other)
    {
        yield return new WaitForSeconds(.2f);

        other.gameObject.GetComponent<BoxCollider>().isTrigger = false;

    }
}
