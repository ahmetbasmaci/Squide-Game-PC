using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class Lvl1_MyPlayer : MonoBehaviour
{
    public bool isDead = false;
    public bool isWon = false;
    public bool isStarted = false;
    

    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
        Time.timeScale = 1f;
    }
	
    void Start()
    {
        foreach (var chailRb in GetComponentsInChildren<Rigidbody>())
            chailRb.useGravity = false;

        foreach (var coll in GetComponentsInChildren<Collider>())
            coll.enabled = false;

        //GetComponent<Rigidbody>().useGravity = true;
        GetComponent<CharacterController>().enabled= true;
    }
    
    public void Dead()
    {
        if (isDead) return;

        isDead = true;
        anim.enabled = false;


        foreach (var coll in GetComponentsInChildren<Collider>())
            coll.enabled = true;

        foreach (var chailRb in GetComponentsInChildren<Rigidbody>())
            chailRb.useGravity = true;

        GetComponent<ThirdPersonController>().enabled = false;

        Time.timeScale = 0.3f;

        Lvl1_Manager.instance.LevelField();

    }
    
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(Tags.STARTLINE))
        {
            isStarted = true;
        }
        else if (other.CompareTag(Tags.WINLINE))
        {
            isWon = true;
            Lvl1_Manager.instance.LevelCompleted();
        }
    }
}
