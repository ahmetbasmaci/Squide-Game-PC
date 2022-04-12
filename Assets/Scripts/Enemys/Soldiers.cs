using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldiers : MonoBehaviour
{
    Animator anim;
    void Awake()
    {
        anim=GetComponent<Animator>();
    }

    void Start()
    {
        this.enabled = true;

    }

    void Update()
    {
        if (EnemyGilrControl.instance.playersToKill.Count>0)
        {
            anim.SetBool(Anim_Tags.SOLDIER_FIRE, true);
        }
        else
        {
            anim.SetBool(Anim_Tags.SOLDIER_FIRE, false);
        }
    }
}
