using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3_Ground : MonoBehaviour
{
    [Header("References")]
    public GameObject[] blood_Effect;
    public GameObject deathBlood;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.PLAYER_HIPS))
        {
            Vector3 newPos = collision.transform.position;


            GameObject newBlood = Instantiate(blood_Effect[0], newPos, Quaternion.identity);


            newBlood = Instantiate(blood_Effect[1], newPos, Quaternion.identity);


            GameObject newDeathBlood = Instantiate(deathBlood, newPos, Quaternion.Euler(90, 0, 0));


            Lvl3_Manager.instance.PlayerOnGround();
        }
    }
}
